import {html,render} from '../node_modules/lit-html/lit-html.js';
import {addFormTemplate} from './add-form-template.js'
import {editFormTemplate} from './edit-form-template.js'
import {update,url,list} from '../app.js'

const loadTemplate = () => html`
<button @click=${initialize} id="loadBooks">LOAD ALL BOOKS</button>
`;
const result = loadTemplate();
render(result,document.body);
export const bodyTemplate = (list,editDetails) => html`
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody @click=${onClick}>
        ${list.map(([key,value]) => trTemplate(key,value))}
    </tbody>
    
</table>
${editDetails ? editFormTemplate(editDetails) : addFormTemplate()}
`;

const trTemplate = (id,obj) => html`
<tr data-id=${id}>
    <td>${obj.title}</td>
    <td>${obj.author}</td>
    <td>
        <button class="edit">Edit</button>
        <button class="delete">Delete</button>
    </td>
</tr>
`;

async function initialize(){
    const response = await fetch(url);
    const responseData = await response.json();
    console.log(Object.entries(responseData));
    Object.entries(responseData).forEach(x=> list.push(x));

    update();
}

function onClick(event){
    if (event.target.classList.contains('edit')) {
        const parentNode = event.target.parentNode.parentNode;
        const title = parentNode.firstElementChild.textContent;
        const author = parentNode.firstElementChild.nextElementSibling.textContent;
        const isEdit = true;
        const id = event.target.parentNode.parentNode.dataset.id;

        update({title,author,isEdit,id});
    } else if(event.target.classList.contains('delete')){
        event.target.parentNode.parentNode.remove();
        onDelete(event);
    }
}

async function onDelete(event) {
    const id = event.target.parentNode.parentNode.dataset.id;

    await fetch(`${url}/`+id,{
        method:'DELETE',
    })

    const item = list.find(([key,value])=>key == id);
    const index = list.indexOf(item);
    list.splice(index,1);
    update();
}
