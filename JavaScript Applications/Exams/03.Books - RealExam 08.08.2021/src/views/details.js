import { html } from '../../node_modules/lit-html/lit-html.js';
import {ifDefined} from '../../node_modules/lit-html/directives/if-defined.js';

import { deleteById, getById, createLike, getTotalCountOfLikesForBook, getLikesForBookFromASpecificUser } from '../api/data.js';

const detailsTemplate = (book, isOwner, isLoggedIn, onDelete, onLike, bookLikes, isLikedByUser) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">Type: ${book.type}</p>
        <p class="img"><img src=${book.imageUrl}></p>
        <div class="actions">
            ${isOwner ? html`
            <a class="button" href="/edit/${book._id}">Edit</a>
            <a class="button" href="javascript:void(0)" @click=${onDelete}>Delete</a>` : ''}
            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            ${
                isOwner == false && isLoggedIn == true && isLikedByUser == false ? html`<a class="button"
                href="javascript:void(0)" @click=${onLike}>Like</a>` : ''}
            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${bookLikes}</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${book.description}</p>
    </div>
</section>
`;

export async function detailsPage(ctx) {
    const userId = ctx.userId;
    const book = await getById(ctx.params.id);
    let bookLikes = await getTotalCountOfLikesForBook(ctx.params.id);

    const isOwner = book._ownerId == ctx.userId;
    const isLoggedIn = ctx.userToken ? true : false;
    let userLikes = '';
    let isLikedByUser = '';
    if (isLoggedIn) {
        userLikes = await getLikesForBookFromASpecificUser(book._id, userId);
        isLikedByUser = userLikes == 1 ? true : false;
        ctx.render(detailsTemplate(book, isOwner, isLoggedIn, onDelete, onLike, bookLikes,isLikedByUser));
    } else {
        ctx.render(detailsTemplate(book, isOwner, isLoggedIn, onDelete, onLike, bookLikes,true));
    }
    
    async function onDelete() {
        const isConfirmed = confirm('Do you want to delete this book?');
        if (isConfirmed) {
            await deleteById(book._id);
            ctx.page.redirect('/all');
        }
    }

    async function onLike(event) {
        event.preventDefault();
        const bookId = book._id;
        await createLike({ bookId });
        
        
        bookLikes = await getTotalCountOfLikesForBook(ctx.params.id);
        isLikedByUser = true;
        ctx.render(detailsTemplate(book, isOwner, isLoggedIn, onDelete, onLike, bookLikes, isLikedByUser));
    }
}