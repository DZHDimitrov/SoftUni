import { html } from '../../node_modules/lit-html/lit-html.js';
import { getRequestsByTeamId, getTeamById, requestToJoin, cancelMembership, approveMembership } from '../api/data.js';
import { until } from '../../node_modules/lit-html/directives/until.js';
import { loaderTemplate } from './common/loader.js'

const detailsTeamTemplate = (team, isOwner, createControls, members, pending) => html`
<section id="team-home">
    <article class="layout">
        <img src=${team.logoUrl} class="team-logo left-col">
        <div class="tm-preview">
            <h2>${team.name}</h2>
            <p>${team.description}</p>
            <span class="details">${team.memberCount} Members</span>
            <div>
                ${createControls()}
            </div>
        </div>
        <div class="pad-large">
            <h3>Members</h3>
            <ul class="tm-members">
                ${members.map(x=> memberTemplate(x,isOwner))}
            </ul>
        </div>

        ${isOwner ? html` <div class="pad-large">
            <h3>Membership Requests</h3>
            <ul class="tm-members">
                ${pending.map(pendingMemberTemplate)}
            </ul>
        </div>` : ''}

    </article>
</section>
`;

const memberTemplate = (request, isOwner) => html`
<li>
    ${request.user.username}
    ${isOwner ? html`<a @click=${e => request.decline} href="javascript:void(0)" class="tm-control action">Remove from team</a>` : ''}
</li>
`;

const pendingMemberTemplate = (request) => html`
<li>
    ${request.user.username}
    <a @click=${request.approve} href="javascript:void(0)" class="tm-control action">Approve</a>
    <a @click=${request.decline} href="javascript:void(0)" class="tm-control action">Decline</a>
</li>
`;

export async function detailsPage(ctx) {
    const teamId = ctx.params.id;
    const userId = ctx.userId;
    ctx.render(until(await populateTemplate(teamId), loaderTemplate()))

    async function populateTemplate(teamId) {
        const [team, requests] = await Promise.all([getTeamById(teamId), getRequestsByTeamId(teamId)]);
        const isOwner = userId == team._ownerId;
        requests.forEach(x => {
            x.approve = (e) => approve(e, x);
            x.decline = (e) => leave(e, x._id);});
        const members = requests.filter(x => x.status == 'member');
        const pending = requests.filter(x => x.status == 'pending');
        team.memberCount = members.length;
        console.log(pending);
        return detailsTeamTemplate(team, isOwner, createControls, members, pending);

        async function join(event) {
            event.target.remove();
            await requestToJoin(teamId);
            ctx.render(await populateTemplate(teamId));
        }

        async function leave(event, requestId) {
            const confirmed = confirm('Are you sure?')
            if (confirmed) {
                event.target.remove();
                await cancelMembership(requestId);
                ctx.render(await populateTemplate(teamId));
            }
        }
        function createControls() {
            const request = requests.find(x => x._ownerId == userId);
            if (userId != null) {
                if (userId == team._ownerId) {
                    return html`<a href=/edit/${team._id} class="action">Edit team</a>`
                } else if (request && request.status == 'member') {
                    return html`<a @click=${e => leave(e, request._id)} href="javascript:void(0)" class="action invert">Leave team</a>`;
                } else if (request && request.status == 'pending') {
                    return html`Membership pending. <a @click=${e => leave(e, request._id)} href="javascript:void(0)">Cancel request</a>`;
                } else {
                    return html`<a @click=${join} href="javascript:void(0)" class="action">Join team</a>`;
                }
            } else {
                return '';
            }
        }

        async function approve(event, request) {
            event.target.remove();
            await approveMembership(request);
            ctx.render(await populateTemplate(teamId));
        }
    }
}


