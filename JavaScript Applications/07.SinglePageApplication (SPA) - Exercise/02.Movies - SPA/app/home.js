import {e} from './dom.js'
import {showCreate} from './createMovie.js'
import {createMovieBtn} from './common.js'
import {showDetails} from './details.js'

let body;
let section;

async function getMovies() {
    const response = await fetch('http://localhost:3030/data/movies');
    const data = await response.json();

    return data;
}

function createMovie(movie) {
    const cardMovie =
     e('div',{className:'card mb-4'},
        e('img',{className:'card-img-top',src:`${movie.img}`,width:400}),
        e('div',{className:'card-body'},
            e('h4',{className:'card-title'},`${movie.title}`)),
        e('div',{className:'card-footer'},
            e('a',{},
                e('button',{type:'button',className:'btn btn-info'},'Details'))));
    cardMovie.setAttribute('data-id',movie._id);
    return cardMovie;
}
export function setupHome(bodyTarget,sectionTarget) {
    body = bodyTarget;
    section = sectionTarget;
    section.querySelector('#createMovieLink').addEventListener('click', () => {
        showCreate();
    });
    section.addEventListener('click', (e) => {
        if (e.target.tagName == 'BUTTON' && e.target.textContent == 'Details') {
            const movieId = e.target.parentNode.parentNode.parentNode.dataset.id;
            showDetails(movieId);
        }
    })
}

export async function showHome() {
    body.querySelector('section').remove();
    
    const movieSection = section.querySelector('.card-deck.d-flex.justify-content-center');
    movieSection.innerHTML = '';
    const movies = await getMovies();
    console.log(movies);
    movies.forEach(x=> movieSection.appendChild(createMovie(x)));
    document.querySelector('nav').insertAdjacentElement('afterend',section);
    if (!localStorage.getItem('userToken')) {
        createMovieBtn.style.display = 'none';
    }
    console.log(movieSection.children.length);
    
}