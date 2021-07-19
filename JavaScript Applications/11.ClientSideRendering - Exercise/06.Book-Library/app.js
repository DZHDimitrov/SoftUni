import {render} from './node_modules/lit-html/lit-html.js';
import {bodyTemplate} from './templates/page-template.js';

const body = document.body;
export const url = 'http://localhost:3030/jsonstore/collections/books';
export let list = [];

export function update(editDetails){
    const result = bodyTemplate(list,editDetails);
    render(result,body);
}

