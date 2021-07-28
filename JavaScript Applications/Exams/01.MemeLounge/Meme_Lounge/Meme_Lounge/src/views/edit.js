import { html } from '../../node_modules/lit-html/lit-html.js';
import { getMemeDetailsById, editMemeById } from '../api/data.js';
import { notify } from '../views/notification.js'

const editTemplate = (meme, onSubmit) => html`
<section id="edit-meme">
    <form id="edit-form" @submit=${onSubmit}>
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description" .value=${meme.description}>

            </textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${meme.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>
`;

export async function editPage(ctx) {
    const memeId = ctx.params.id;

    const meme = await getMemeDetailsById(memeId);
    ctx.render(editTemplate(meme, onSubmit))

    async function onSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.currentTarget);

        const title = formData.get('title');
        const description = formData.get('description');
        const imageUrl = formData.get('imageUrl');

        try {
            if (!title || !description || !imageUrl) {
                throw new Error('All fields are required!')
            }
            await editMemeById(memeId, { title, description, imageUrl });
            ctx.page.redirect(`/details/${memeId}`);
        } catch (error) {
            notify(error.message);
        }
    }
}