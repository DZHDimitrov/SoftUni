import { ce } from './dom.js';

const catchesElement = document.getElementById('catches');
const loginElement = document.getElementById('guest');
const logoutElement = document.getElementById('user');

if (sessionStorage.getItem('userToken')) {
    loginElement.style.display = 'none';
    logoutElement.style.display = 'inline-block';
} 
function attachEvents() {
    const addBtn = document.querySelector('#addForm button.add');
    addBtn.disabled = sessionStorage.getItem('userToken') ? false : true;
    addBtn.addEventListener('click', addNewCatch);

    [...catchesElement.children].forEach(x => x.remove());
    document.getElementById('loadCatches').addEventListener('click', loadCatches);
    catchesElement.addEventListener('click', editHandler);

    logoutElement.addEventListener('click',logout);
}

async function logout() {
    const token = sessionStorage.getItem('userToken');
    console.log(token);
    const url = 'http:localhost:3030/users/logout';

    //AJAX Request GET
    await fetch(url,{
        method: 'GET',
        headers: {'X-Authorization':token},
    });

    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('userToken');

    loginElement.style.display = 'inline-block';
    logoutElement.style.display = 'none';

    document.getElementById('user').style.display = 'none';
    window.location.pathname = '05.Fisher-Game/index.html';

}

async function loadCatches() {
    [...catchesElement.children].forEach(x => x.remove());
    const url = 'http://localhost:3030/data/catches';

    //AJAX Request GET
    const response = await fetch(url);
    const data = await response.json();
    Object.values(data).forEach((value) => catchesElement.appendChild(createCatch(value)));
}

async function addNewCatch(e) {
    const currentCatch = document.getElementById('addForm')
    const angler = currentCatch.querySelector('.angler');
    const weight = currentCatch.querySelector('.weight');
    const species = currentCatch.querySelector('.species');
    const location = currentCatch.querySelector('.location');
    const bait = currentCatch.querySelector('.bait');
    const captureTime = currentCatch.querySelector('.captureTime');
    const token = sessionStorage.getItem('userToken');
    const aside = document.querySelector('aside');

    if (!angler.value || !weight.value || !species.value || !location.value || !bait.value || !captureTime.value) {
        if (!aside.querySelector('span')) {
            const spanElement = ce('span', { style: 'color:red' }, 'Invalid input!');
            aside.appendChild(spanElement);
        }
        return;
    }

    if (aside.querySelector('span')) {
        aside.querySelector('span').remove();
    }

    const obj = {
        angler: angler.value,
        weight: Number(weight.value),
        species: species.value,
        location: location.value,
        bait: bait.value,
        captureTime: Number(captureTime.value),
    }

    angler.value = '';
    weight.value = '';
    species.value = '';
    location.value = '';
    bait.value = '';
    captureTime.value = '';

    //AJAX Request POST
    const url = 'http://localhost:3030/data/catches';
    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token,
        },
        body: JSON.stringify(obj),
    });


    if (response.ok) {
        const data = await response.json();
        catchesElement.appendChild(createCatch(data));
    } else {
        const error = await response.json();
        console.error(error.message);
    }
}

async function editHandler(e) {
    if (e.target.className == 'update') {
        const currentCatch = e.target.parentElement;
        const catchId = currentCatch.dataset.id;
        const token = sessionStorage.getItem('userToken');

        const angler = currentCatch.querySelector('.angler');
        const weight = currentCatch.querySelector('.weight');
        const species = currentCatch.querySelector('.species');
        const location = currentCatch.querySelector('.location');
        const bait = currentCatch.querySelector('.bait');
        const captureTime = currentCatch.querySelector('.captureTime');

        const obj = {
            angler: angler.value,
            weight: Number(weight.value),
            species: species.value,
            location: location.value,
            bait: bait.value,
            captureTime: Number(captureTime.value),
        }
        const url = `http://localhost:3030/data/catches/${catchId}`;

        //AJAX Request PUT
        const response = await fetch(url, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(obj),
        });
    } else if (e.target.className == 'delete') {
        const currentCatch = e.target.parentElement;
        const catchId = currentCatch.dataset.id;
        const token = sessionStorage.getItem('userToken');

        const url = `http://localhost:3030/data/catches/${catchId}`;

        //AJAX Request DELETE
        const response = await fetch(url, {
            method: 'DELETE',
            headers: { 'X-Authorization': token },
        });
        currentCatch.remove();
    }
}
function createCatch(value) {
    const labelAngler = ce('label', undefined, 'Angler');
    const inputAngler = ce('input', { class: 'angler' }, value.angler);
    const hrOne = ce('hr');

    const labelWeight = ce('label', undefined, 'Weight');
    const inputWeight = ce('input', { class: 'weight' }, Number(value.weight));
    const hrTwo = ce('hr');

    const labelSpecies = ce('label', undefined, 'Species');
    const inputSpecies = ce('input', { class: 'species' }, value.species);
    const hrThree = ce('hr');

    const labelLocation = ce('label', undefined, 'Location');
    const inputLocation = ce('input', { class: 'location' }, value.location);
    const hrFour = ce('hr');

    const labelBait = ce('label', undefined, 'Bait');
    const inputBait = ce('input', { class: 'bait' }, value.bait);
    const hrFive = ce('hr');

    const labelCaptureTime = ce('label', undefined, 'Capture Time');
    const inputCaptureTime = ce('input', { class: 'captureTime' }, Number(value.captureTime));
    const hrSix = ce('hr');

    const btnUpdate = ce('button', { class: 'update' }, 'Update');
    btnUpdate.disabled = value._ownerId == sessionStorage.getItem('userId') ? false : true;
    const btnDelete = ce('button', { class: 'delete' }, 'Delete');
    btnDelete.disabled = value._ownerId == sessionStorage.getItem('userId') ? false : true;

    const divElement = ce('div', { class: 'catch', 'data-id': value._id });
    divElement.append(
        labelAngler, inputAngler, hrOne,
        labelWeight, inputWeight, hrTwo,
        labelSpecies, inputSpecies, hrThree,
        labelLocation, inputLocation, hrFour,
        labelBait, inputBait, hrFive,
        labelCaptureTime, inputCaptureTime, hrSix,
        btnUpdate, btnDelete,
    );
    console.log(divElement);
    return divElement;
}

attachEvents();

