import { showDetails } from './details.js'

document.querySelector('form').addEventListener('submit', onCreateSubmit);

async function onCreateSubmit(data) {
    const body = JSON.stringify({
        name: data.name,
        img: data.img,
        ingredients: data.ingredients.split('\n').map(l => l.trim()).filter(l => l != ''),
        steps: data.steps.split('\n').map(l => l.trim()).filter(l => l != ''),
    })
    const token = sessionStorage.getItem('userToken');

    if (token == null) {
        return alert('You are not logged in')
    }

    try {
        const response = await fetch('http://localhost:3030/data/recipes', {
            method: 'post',
            headers: { 'Content-Type': 'application/json', 'X-Authorization': token },
            body,
        });
        if (response.status == 200) {
            const recipe = await response.json();
            showDetails(recipe._id);
        } else {
            throw new Error(await response.json())
        }
    } catch (error) {
        console.error(error.message)
    }
}

let main;
let section;
let setActiveNav;

export function setupCreate(mainTarget, sectionTarget, setActiveNavCb) {
    
    main = mainTarget;
    section = sectionTarget;
    setActiveNav = setActiveNavCb;
    section.querySelector('form').addEventListener('submit', (ev => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        onCreateSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
        ev.target.reset();
    }));
}

export function showCreate() {
    main.innerHTML = '';
    setActiveNav('createLink');
    main.appendChild(section);
}