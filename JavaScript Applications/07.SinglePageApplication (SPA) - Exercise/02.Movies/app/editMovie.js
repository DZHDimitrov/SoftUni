import {showHome} from './home.js';
async function onEditSubmit(data){
    if (!data.title || !data.description || !data.imageUrl) {
        return alert('All fields are required!')
    }
    const movieId = data.movieId;
    const body = JSON.stringify({
        title: data.title,
        description: data.description,
        imageUrl: data.imageUrl,
    })
    const token = localStorage.getItem('userToken');
    const response = await fetch('http://localhost:3030/data/movies/'+movieId,{
        method: 'PUT',
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

let body;
let section;

export function setupEdit(bodyTarget,sectionTarget) {
    body = bodyTarget;
    section = sectionTarget;

    
    section.querySelector('form').addEventListener('submit',(ev) => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        onEditSubmit([...formData.entries()].reduce((p,[k,v]) => Object.assign(p,{[k]:v}),{}));
    })
}

export async function showEdit(e,movie){
    [...body.querySelectorAll('section')].forEach(x=> x.remove());
    document.querySelector('nav').insertAdjacentElement('afterend',section);

    const form = document.getElementById('edit-movie');
    const title = form.querySelector('form [name="title"]');
    const description = form.querySelector('form [name="description"]');
    const img = form.querySelector('form [name="imageUrl"]');

    title.value = movie.title;
    description.value = movie.description;
    img.value = movie.img;
    form.querySelector('form [name="movieId"]').value = movie._id;
    
}