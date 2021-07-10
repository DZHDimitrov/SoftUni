import { e } from './dom.js'
import { showDetails } from './details.js';

export async function getRecipes() {
    const response = await fetch('http://localhost:3030/data/recipes?select=_id%2Cname%2Cimg');
    const recipes = await response.json();

    return Object.values(recipes);
}


export function createRecipePreview(recipe) {
    const result = e('article', { className: 'preview', onClick: () => showDetails(recipe._id) },
        e('div', { className: 'title' }, e('h2', {}, recipe.name)),
        e('div', { className: 'small' }, e('img', { src: recipe.img })),
    );

    return result;
}

let main;
let section;
let setActiveNav;

export function setupCatalog(mainTarget,sectionTarget,setActiveNavCb){
    main = mainTarget;
    section = sectionTarget;
    setActiveNav = setActiveNavCb;
}

export async function showCatalog() {
    setActiveNav('catalogLink');
    section.innerHTML = '<p style="color: white">Loading...</p>';
    main.innerHTML = '';
    main.appendChild(section);

    const data = await getRecipes();
    const cards = data.map(createRecipePreview);

    section.innerHTML = '';
    const fragment = document.createDocumentFragment();
    cards.forEach(x=> fragment.appendChild(x));
    section.appendChild(fragment);
}