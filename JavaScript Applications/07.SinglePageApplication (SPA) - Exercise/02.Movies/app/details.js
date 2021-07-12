import { e } from './dom.js'
import {showEdit} from './editMovie.js'
import {showHome} from './home.js'

async function getLikesById(id) {
    const response = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`);
    const data = await response.json();
    return data;
}

async function getOwnLikesByMovieId(id) {
    const userId = localStorage.getItem('userId');
    const response = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userId}%22`);
    const data = await response.json();
    return data;
}

async function getMovieById(id) {
    const response = await fetch('http://localhost:3030/data/movies/' + id);
    const data = await response.json();
    return data;
}

async function onDelete(e, id) {
    e.preventDefault();
    const confirmed = confirm('Are you sure you want to delete this movie?')
    if (confirmed) {
        const response = await fetch('http://localhost:3030/data/movies/' + id, {
            method: 'DELETE',
            headers: { 'X-Authorization': localStorage.getItem('userToken') }
        });
        if (response.ok) {
            alert('Movie deleted');
            showHome();
        }
    }
    else {
        const error = await response.json();
        alert(error.message);
    }
}
function createMovieCard(movie, likes, ownLike) {
    const controls = e('div', { className: 'col-md-4 text-center' },
        e('h3', { className: 'my-3' }, 'Movie Description'),
        e('p', {}, movie.description),
    );

    const userId = localStorage.getItem('userId');

    if (userId != null) {
        if (userId == movie._ownerId) {
            controls.appendChild(e('a', { className: 'btn btn-danger', href: '#', onClick: (e) => onDelete(e, movie._id) }, 'Delete'))
            controls.appendChild(e('a', { className: 'btn btn-warning', href: '#' ,onClick: (e) => showEdit (e,movie)}, 'Edit'))
        } else if (ownLike.length == 0) {
            controls.appendChild(e('a', { className: 'btn btn-primary', href: '#', onClick: likeMovie }, 'Like'))
        }
    }
    const likesSpan = e('span', { className: 'enrolled-span' }, likes + ' like' + (likes == 1 ? '' : 's'))
    controls.appendChild(likesSpan)

    const element = document.createElement('div');
    element.className = 'container';
    element.appendChild(e('div', { className: 'row bg-light text-dark' },
        e('h1', {}, `Movie title: ${movie.title}`),
        e('div', { className: 'col-md-8' },
            e('img', { className: 'img-tumbnail', src: movie.img })),
        controls
    ));
    return element;

    async function likeMovie(event) {
        const response = await fetch('http://localhost:3030/data/likes', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json', 'X-Authorization': localStorage.getItem('userToken') },
            body: JSON.stringify({ movieId: movie._id })
        });

        if (response.ok) {
            event.target.remove();
            likes++;
            likesSpan.textContent = likes + ' like' + (likes == 1 ? '' : 's');
        }
    }

}

let body;
let section;

export function setupDetails(bodyTarget, sectionTarget) {
    body = bodyTarget;
    section = sectionTarget;
}

export async function showDetails(id) {
    body.querySelector('nav').nextElementSibling.remove();
    section.innerHTML = '';
    const [movie, likes, ownLike] = await Promise.all([getMovieById(id), getLikesById(id), getOwnLikesByMovieId(id)]);
    section.appendChild(createMovieCard(movie, likes, ownLike));
    document.querySelector('nav').insertAdjacentElement('afterend', section);
}