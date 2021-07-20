import { html } from './node_modules/lit-html/lit-html.js';

export const cardTemplate = (data) => html`
<div class="contact card">
    <div>
        <i class="far fa-user-circle gravatar"></i>
    </div>
    <div class="info">
        <h2>Name: ${data.name}</h2>
        <button @click=${onClick} class="detailsBtn">Details</button>
        <div class="details" id=${data.id}>
            <p>Phone number: ${data.phoneNumber}</p>
            <p>Email: ${data.email}</p>
        </div>
    </div>
</div>`;

function onClick(event){
    const details = event.target.parentNode.querySelector('.details');
    if (details.style.display == 'block') {
        details.style.display = 'none';
    }else {
        details.style.display = 'block';
    }
}