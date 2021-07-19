import {html,render} from './node_modules/lit-html/lit-html.js';
import {cats} from './catSeeder.js';

const ulCatsTemplate = (cats) => html`<ul>${cats}</ul>`;
const catElementTemplate = (cat) => html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button @click="${onClick}" class="showBtn">Show status code</button>
        <div class="status" style="display: none" id="${cat.id}">
            <h4>${cat.statusCode}</h4>
            <p>Continue</p> 
        </div>
    </div>
</li>
`;
const catsSection = document.getElementById('allCats');
const allCats = cats.map(catElementTemplate);
const result = ulCatsTemplate(allCats);
render(result,catsSection);

function onClick(event) {
    const statusElement = event.target.parentNode.querySelector('.status');
    if (statusElement.style.display == 'block') {
        statusElement.style.display = 'none';
        event.target.parentNode.querySelector('.showBtn').textContent = 'Show status code';
    } else {
        statusElement.style.display = 'block';
        event.target.parentNode.querySelector('.showBtn').textContent = 'Hide status code';
    }
}