import {getIdeaById,deleteIdeaById} from '../api/data.js';
import { e } from '../dom.js';

export function setDetails(section,navigation){
    return showDetails;
    
    async function showDetails(id) {
        section.innerHTML = '';
        const idea = await getIdeaById(id);
        section.appendChild(createIdea(idea));
        return section
    }

    function createIdea(idea){
        const fragment = document.createDocumentFragment();
        const token = sessionStorage.getItem('authToken');
        const userId = sessionStorage.getItem('userId');
        const ownerId = idea._ownerId;
        const ideaId = idea._id;
    
        fragment.append(e('img',{className:'det-img',src:idea.img}),
        e('div',{className:'desc'},
            e('h2',{className:'display-5'},idea.title),
            e('p',{className:'infoType'},'Description:'),
            e('p',{className:'idea-description'},idea.description)));
        
        if (token != null && ownerId == userId) {
            fragment.appendChild(
            e('div',{className:'text-center'},
                e('a',{className:'btn detb',href:'',onClick:(event) => onDelete(event,ideaId)},'Delete')));
        }
    
        return fragment;
    }
    
    async function onDelete(event,ideaId){
        console.log(ideaId);
        event.preventDefault();
        await deleteIdeaById(ideaId);
        navigation.changeView('dashboard');
    }
}