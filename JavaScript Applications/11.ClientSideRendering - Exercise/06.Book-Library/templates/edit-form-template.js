import {html} from '../node_modules/lit-html/lit-html.js';
import {update,url,list} from '../app.js';

export const editFormTemplate = (data) => html`
<form id="edit-form" @submit=${onEdit}>
    <input type="hidden" value=${data.id} name="id">
    <h3>Edit book</h3>
    <label>TITLE</label>
    <input  type="text" name="title" value=${data.title} placeholder="Title...">
    <label>AUTHOR</label>
    <input  type="text" name="author" value=${data.author} placeholder="Author...">
    <input type="submit" value="Save">
</form>
`;

async function onEdit(event){
    event.preventDefault();
    const form = event.target;

    const title = form.querySelector('[name="title"]').value;
    const author = form.querySelector('[name="author"]').value;
    const id = form.querySelector('[type="hidden"]').value;
    const body = JSON.stringify({title,author});
    console.log(id);
    const response = await fetch(`${url}/`+id,{
        method:'PUT',
        headers: {'Content-Type':'application/json'},
        body
    });
    let element = list.find(([key,value])=> key == id);
    console.log(element);
    const data = await response.json();

    element[1].title = data.title;
    element[1].author = data.author;
    
    update();
}