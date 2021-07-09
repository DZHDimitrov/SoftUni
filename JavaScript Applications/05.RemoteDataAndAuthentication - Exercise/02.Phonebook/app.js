function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click',load);
    document.getElementById('btnCreate').addEventListener('click',create)
    document.getElementById('phonebook').addEventListener('click',del);
}

async function load(e) {
    const url = 'http://localhost:3030/jsonstore/phonebook';

    const outputList = document.getElementById('phonebook');
    [...outputList.children].forEach(x=>x.remove());
    const fragment = document.createDocumentFragment();

    //AJAX Request GET
    const response = await fetch(url);
    const data = await response.json();
    console.log(data);
    Object.entries(data).forEach(([key,value]) => {
        let liElement = document.createElement('li');
        liElement.textContent = `${value.person}: ${value.phone}`;
        liElement.dataset.id = key;

        let btnDelete = document.createElement('button');
        btnDelete.textContent = 'Delete';
        liElement.appendChild(btnDelete);
        fragment.appendChild(liElement);
    });

    outputList.appendChild(fragment);
}
async function create(e){
    const personElement = document.getElementById('person');
    const phoneElement = document.getElementById('phone');

    const person = personElement.value;
    const phone = phoneElement.value;

    if (!person || !phone) {
        return;
    }

    const obj = {
        person,
        phone
    }

    personElement.value = '';
    phoneElement.value = '';

    const url = 'http://localhost:3030/jsonstore/phonebook';

    //AJAX Request POST
    const response = await fetch(url, {
        method: 'POST',
        headers: {'Content-Type':'application/json'},
        body:JSON.stringify(obj),
    });
    load();
}
async function del(e) {
    if (e.target.textContent != 'Delete') {
        return;
    }
    const liElement = e.target.parentElement;
    const itemId = liElement.dataset.id;
    const url = 'http://localhost:3030/jsonstore/phonebook/'+itemId;
    //AJAX Request DELETE
    const response = await fetch(url, {
        method:'DELETE'
    });
    liElement.remove();
    
}

attachEvents();