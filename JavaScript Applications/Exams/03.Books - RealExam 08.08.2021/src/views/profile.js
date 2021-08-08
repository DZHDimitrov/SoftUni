import {html} from '../../node_modules/lit-html/lit-html.js';
import { getUserBooks } from '../api/data.js';

const personalBooksTemplate = (userBooks) => html`
 <!-- My Books Page ( Only for logged-in users ) -->
 <section id="my-books-page" class="my-books">
    <h1>My Books</h1>
    <!-- Display ul: with list-items for every user's books (if any) -->
    ${userBooks.length > 0 ? html`
    <ul class="my-books-list">
        ${userBooks.map(singleBookTemplate)}
    </ul>
    `: html`<p class="no-books">No books in database!</p>`}
    <!-- Display paragraph: If the user doesn't have his own books  -->
    
</section>
`;

const singleBookTemplate = (book) => html`
<li class="otherBooks">
    <h3>${book.title}</h3>
    <p>Type: ${book.type}</p>
    <p class="img"><img src=${book.imageUrl}></p>
    <a class="button" href="/details/${book._id}">Details</a>
</li>
`;

export async function profilePage(ctx){
    const userBooks =await getUserBooks(ctx.userId);
    ctx.render(personalBooksTemplate(userBooks));
}