import { html } from '../../node_modules/lit-html/lit-html.js';

import {editById,getById} from '../api/data.js';

const editTemplate = (book,onSubmit) => html`
 <!-- Edit Page ( Only for the creator )-->
 <section id="edit-page" class="edit">
    <form id="edit-form" action="#" method="" @submit=${onSubmit}>
        <fieldset>
            <legend>Edit my Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" .value=${book.title}>
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description"
                        id="description" .value=${book.description}></textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" .value=${book.imageUrl}>
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" .value=${book.type}>
                        <option value="Fiction" selected>Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save">
        </fieldset>
    </form>
</section>
`;

export async function editPage(ctx) {
    const bookToEdit = await getById(ctx.params.id);
    ctx.render(editTemplate(bookToEdit,onSubmit));

    async function onSubmit(event){
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
            await editById(bookToEdit._id,{title,description,imageUrl,type});
            ctx.page.redirect(`/details/${bookToEdit._id}`);
        } catch (error) {
            alert(error.message);
        }
    }
}