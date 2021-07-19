import { render, html } from './node_modules/lit-html/lit-html.js'
import {towns} from './towns.js';

const searchTemplate = (towns,match) => html`
<article>
   <div id="towns">
      <ul>${towns.map(x=> townTemplate(x,match))}</ul>
   </div>
   <input type="text" id="searchText" />
   <button @click=${search}>Search</button>
   <div id="result">${countMatches(towns,match)}</div>
</article>
`;

const townTemplate = (name,match) => html`
<li class=${(match && name.toLowerCase().includes(match.toLowerCase())) ? 'active' : ''}>${name}</li>`;

update();
function update(match = '') {
   const result = searchTemplate(towns,match);
   render(result,document.body);
}

function search(event) {
   const match = event.target.parentNode.querySelector('input').value;
   update(match);
}

function countMatches(towns,match) {
   const matches = towns.filter(x=>match && x.toLowerCase().includes(match.toLowerCase())).length;
   if (matches) {
      return `${matches} matches found`;
   }else {
      return '';
   }
}
