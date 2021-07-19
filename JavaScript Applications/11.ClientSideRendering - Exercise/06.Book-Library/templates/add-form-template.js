import {html} from '../node_modules/lit-html/lit-html.js';
import {update,url,list} from '../app.js';

export const addFormTemplate = () => html`
<form id="add-form" @submit=${onSubmit}>
    <h3>Add book</h3>
    <label>TITLE</label>
    <input type="text" name="title" placeholder="Title...">
    <label>AUTHOR</label>
    <input type="text" name="author" placeholder="Author...">
    <input type="submit" value="Submit">
</form>
`;

async function onSubmit(event) {
    event.preventDefault();
    const form = event.target;
    

    const title = form.querySelector('[name="title"]').value;
    const author = form.querySelector('[name="author"]').value;
    const body = JSON.stringify({title,author});
    if (!title || !author || !body) {
        return alert('All fields are required!')
    }
    form.reset();

    const response = await fetch(url,{
        method:'POST',
        headers: {'Content-Type':'application/json'},
        body,
    });

    const data = await response.json();

    const arr  = [
        data._id,{
            title,author
        }
    ]
    list.push(arr);
    update();
}