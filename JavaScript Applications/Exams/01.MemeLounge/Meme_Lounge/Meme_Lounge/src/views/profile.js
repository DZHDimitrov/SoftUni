import {html} from '../../node_modules/lit-html/lit-html.js';
import {getMyMemes} from '../api/data.js';

const profileTemplate = (userInfo) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src="/images/${userInfo.gender == 'male' ? 'male' : 'female'}.png">
        <div class="user-content">
            <p>Username: ${userInfo.username}</p>
            <p>Email: ${userInfo.email}</p>
            <p>My memes count: ${userInfo.memes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        <!-- Display : All created memes by this user (If any) --> 
        ${userInfo.memes.length > 0 ? userInfo.memes.map(singleMemeTemplate) : html`<p class="no-memes">No memes in database.</p>`}
        <!-- Display : If user doesn't have own memes  --> 
    </div>
</section>
`;

const singleMemeTemplate = (meme) => html`
<div class="user-meme">
    <p class="user-meme-title">${meme.title}</p>
    <img class="userProfileImage" alt="meme-img" src=${meme.imageUrl}>
    <a class="button" href="/details/${meme._id}">Details</a>
</div>
`;

export async function userProfilePage(ctx) {
    const userId = ctx.userId;
    const username = ctx.username;
    console.log(username);
    const gender = ctx.gender;
    const email = ctx.email;
    const memesOfUser = await getMyMemes(userId);

    const userInfo = {
        gender,
        username,
        email,
        memes: memesOfUser,
    }
    ctx.render(profileTemplate(userInfo));
}