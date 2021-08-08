import { html } from '../../node_modules/lit-html/lit-html.js';

import {getAll} from '../api/data.js';

const allTemplate = (books) => html`
<!-- Dashboard Page ( for Guests and Users ) -->
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    <!-- Display ul: with list-items for All books (If any) -->
    <ul class="other-books-list">
        ${books.length > 0 ? books.map(singleBookTemplate) : html`<p class="no-books">No books in database!</p>`}
    </ul>
</section>
`;

const singleBookTemplate = (book) => html`
<li class="otherBooks">
    <h3>${book.title}</h3>
    <p>Type: ${book.type}</p>
    <p class="img"><img src=${book.imageUrl}></p>
    <a class="button" href=/details/${book._id}>Details</a>
</li>
`;

export async function allPage(ctx) {
    const books = await getAll();
    ctx.render(allTemplate(books));
}