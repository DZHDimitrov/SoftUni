import {html} from '../../node_modules/lit-html/lit-html.js';
import {editTeamById,getTeamById} from '../api/data.js';
import {until} from '../../node_modules/lit-html/directives/until.js';
import {loaderTemplate} from './common/loader.js';

const editTeamTemplate = (onSubmit,team,errorMessage) => html`
<section id="edit">
    <article class="narrow">
        <header class="pad-med">
            <h1>Edit Team</h1>
        </header>
        <form id="edit-form" class="main-form pad-large" @submit=${onSubmit}>
            ${errorMessage ? html`<div class="error">${errorMessage}</div>` : ''}
            <label>Team name: <input type="text" name="name" .value=${team.name}></label>
            <label>Logo URL: <input type="text" name="logoUrl" .value=${team.logoUrl}></label>
            <label>Description: <textarea name="description" .value=${team.description}></textarea></label>
            <input class="action cta" type="submit" value="Save Changes">
        </form>
    </article>
</section>
`;
export async function editPage(ctx) {
    const teamId = ctx.params.id;
    ctx.render(until(populateTemplate(),loaderTemplate()));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.currentTarget);
        const teamName = formData.get('name');
        const logoUrl = formData.get('logoUrl');
        const description = formData.get('description');

        [...event.target.querySelectorAll('input')].forEach(x => x.disabled = true);

        try {
            if (teamName.length < 4) {
                throw new Error('Team name must be at least 4 characters long.');
            }
            if (logoUrl == '') {
                throw new Error('Team logo is required.')
            }
            if (description.length < 10) {
                throw new Error('Description must be atleast 10 characters long.')
            }
            const data = {
                name: teamName,
                logoUrl,
                description
            }
            const team = await editTeamById(teamId,data);

            event.target.reset();
            ctx.page.redirect('/details/' + teamId);

        } catch (error) {
            ctx.render(editTeamTemplate(onSubmit,{name:teamName,logoUrl,description}, error.message))
        } finally {
            [...event.target.querySelectorAll('input')].forEach(x => x.disabled = false);
        }
    }

    async function populateTemplate() {
        const team = await getTeamById(teamId);
        return editTeamTemplate(onSubmit,team);
    }
}