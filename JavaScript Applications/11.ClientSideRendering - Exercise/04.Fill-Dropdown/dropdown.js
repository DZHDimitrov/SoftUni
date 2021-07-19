import {html,render} from './node_modules/lit-html/lit-html.js';

const selectTempalte = (list) => html`
<select id="menu">
    ${list.map(x=> html`<option value=${x._id}>${x.text}</option>>`)}
</select>`;
const main = document.querySelector('div');
const endPoint = 'http://localhost:3030/jsonstore/advanced/dropdown';
const input = document.getElementById('itemText');
getItems();
async function getItems(){
    document.querySelector('form').addEventListener('submit', (event) => addItem(event,list));


    const response = await fetch(endPoint);
    const data = await response.json();
    const list = Object.values(data);

    update(list);
}

function update(list) {
    const result = selectTempalte(list);
    render(result,main);
}
async function addItem(event,list) {
    event.preventDefault();
    const text = input.value;
    const body = JSON.stringify({text});
    event.target.reset();
    const response = await fetch(endPoint,{
        method:'POST',
        headers: {'Content-Type':'application/json'},
        body
    });
    const data = await response.json();
    list.push(data);
    update(list);
}

