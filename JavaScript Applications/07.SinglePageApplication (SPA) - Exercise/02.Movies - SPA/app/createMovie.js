import {showHome} from './home.js'
let body;
let section;

async function onCreate(data){
    if (!data.title || !data.description || !data.imageUrl) {
        return alert('All fields are required!')
    }
    const body = JSON.stringify({
        title: data.title,
        description: data.description,
        imageUrl: data.imageUrl,
    })
    const token = localStorage.getItem('userToken');
    const response = await fetch('http://localhost:3030/data/movies',{
        method: 'POST',
        headers: {'Content-Type':'application/json','X-Authorization':token},
        body
    });
    const responseData = await response.json();
    if (response.status == 200) {
        showHome();
    }else {
        console.error(responseData.message)
    }
}

export function setupCreate(bodyTarget,sectionTarget) {
    body = bodyTarget;
    section = sectionTarget;

    section.querySelector('form').addEventListener('submit',(ev) => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        onCreate([...formData.entries()].reduce((p,[k,v]) => Object.assign(p,{[k]:v}),{}));
    })
}

export function showCreate(){
    [...body.querySelectorAll('section')].forEach(x=> x.remove());
    document.querySelector('nav').insertAdjacentElement('afterend',section);
}

