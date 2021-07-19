import { render, html } from './node_modules/lit-html/lit-html.js';

const tbody = document.querySelector('tbody');
const searchBtn = document.getElementById('searchBtn');
const searchElement = document.getElementById('searchField');


const trTemplate = (student, match) => html`
<tr class=${match ? 'select' : '' }>
   <td>${student.firstName} ${student.lastName}</td>
   <td>${student.email}</td>
   <td>${student.course}</td>
</tr>
`;

getStudents();

async function getStudents() {
   const response = await fetch('http://localhost:3030/jsonstore/advanced/table');
   const data = await response.json();
   const list = Object.values(data);
   searchBtn.addEventListener('click', () => update(list));
   update(list);
}

function update(list) {
   const searchString = searchElement.value;
   searchElement.value = '';
   let result = null;
   if (searchString) {
      result = list.map(x => {
         const match = compareFields(x, searchString);
         return trTemplate(x, match);
      });
   } else {
      result = list.map(x => trTemplate(x, ''))
   }
   render(result, tbody);
}

function compareFields(student, searchString) {
   return Object.values(student).some(studentInfo => {
      const info = studentInfo.toLowerCase();
      const search = searchString.toLowerCase();
      if (info.includes(search) || search.includes(info)) {
         return true;
      }
      return false;
   });
}