import { html } from '../../node_modules/lit-html/lit-html.js';
import { makeNewTeam } from '../api/data.js';

const createTeamTemplate = (onSubmit, errorMessage) => html`
<section id="create">
    <article class="narrow">
        <header class="pad-med">
            <h1>New Team</h1>
        </header>
        <form id="create-form" class="main-form pad-large" @submit=${onSubmit}>
            ${errorMessage ? html`<div class="error">${errorMessage}</div>` : ''}
            <label>Team name: <input type="text" name="name"></label>
            <label>Logo URL: <input type="text" name="logoUrl"></label>
            <label>Description: <textarea name="description"></textarea></label>
            <input class="action cta" type="submit" value="Create Team">
        </form>
    </article>
</section>
`;

export async function createPage(ctx) {
    ctx.render(createTeamTemplate(onSubmit));

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
            const team = await makeNewTeam({ name: teamName, logoUrl, description });

            event.target.reset();
            ctx.page.redirect('/details/' + team._id);

        } catch (error) {
            ctx.render(createTeamTemplate(onSubmit, error.message))
        } finally {
            [...event.target.querySelectorAll('input')].forEach(x => x.disabled = false);
        }
    }
}