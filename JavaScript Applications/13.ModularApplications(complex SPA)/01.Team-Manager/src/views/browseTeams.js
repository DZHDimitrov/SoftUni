import { getAllTeams } from '../api/data.js';
import { html } from '../../node_modules/lit-html/lit-html.js';
import {teamTemplate} from './common/team.js'

const browseTeamsTemplate = (teams) => html`
<section id="browse">

    <article class="pad-med">
        <h1>Team Browser</h1>
    </article>
    <article class="layout narrow">
        <div class="pad-small"><a href="/create" class="action cta">Create Team</a></div>
    </article>
    ${teams.map(teamTemplate)}
</section>
`;

export async function browseTeamsPage(ctx) {
    const teams = await getAllTeams();
    ctx.render(browseTeamsTemplate(teams));
}