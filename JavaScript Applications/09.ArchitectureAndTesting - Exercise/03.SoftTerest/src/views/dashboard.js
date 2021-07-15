import {getIdeas} from '../api/data.js'
import {e} from '../dom.js';

function createIdea(idea){
    const element = 
    e('div',{className:'card overflow-hidden current-card details'},
        e('div',{className:'card-body'},
            e('p',{className:'card-text'},idea.title)),
        e('img',{className:'card-image',src:idea.img,alt:'Card image cap'}),
        e('a',{className:'btn',href:''},'Details'));

    element.style.width = '20rem';
    element.style.height = '18rem';
    element.setAttribute('data-id',idea._id);
    return element;
}

export function setDashboard(section,navigation){
    section.addEventListener('click',event => {
        if (event.target.classList.contains('btn') && event.target.textContent == 'Details') {
            event.preventDefault();
            const cardId = event.target.parentNode.dataset.id;
            navigation.changeView('details',cardId);
        }
    })
    return showDashboard;
    
    async function showDashboard() {
        section.innerHTML = '';
        const ideas = await getIdeas();
        
        if (ideas.length == 0) {
            section.innerHTML = `<h1>No ideas yet! Be the first one :)</h1>`
        }else {
            const ideaElements = ideas.map(createIdea);
            console.log(ideaElements);
            ideaElements.forEach(x=> section.appendChild(x));
        }
        return section
    }
}