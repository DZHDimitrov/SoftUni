import { html } from '../../node_modules/lit-html/lit-html.js';

import {createNew} from '../api/data.js';

const createTemplate = (onSubmit) => html`
 <!-- Create Page ( Only for logged-in users ) -->
 <section id="create-page" class="create">
    <form id="create-form" action="" method="" @submit=${onSubmit}>
        <fieldset>
            <legend>Add new Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" placeholder="Title">
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description" placeholder="Description"></textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" placeholder="Image">
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type">
                        <option value="Fiction">Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Add Book">
        </fieldset>
    </form>
</section>
`;

export async function createPage(ctx) {
    ctx.render(createTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.currentTarget);
        const title = formData.get('title');
        const description = formData.get('description');
        const imageUrl = formData.get('imageUrl');
        const type = formData.get('type');

        try {
            if (!title || !description || !imageUrl || !type) {
                throw new Error('All fields are required!')
            }
            await createNew({title,description,imageUrl,type});
            ctx.page.redirect(`/all`);
        } catch (error) {
            alert(error.message);
        }
    }
}