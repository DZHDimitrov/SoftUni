import {html} from '../../node_modules/lit-html/lit-html.js';
import {getFurnitureDetails,deleteFurniture} from '../api/data.js';

const detailsTemplate = (item,isOwner,onDelete) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src=${item.img} />
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <p>Make: <span>${item.make}</span></p>
        <p>Model: <span>${item.model}</span></p>
        <p>Year: <span>${item.year}</span></p>
        <p>Description: <span>${item.description}</span></p>
        <p>Price: <span>${item.price}</span></p>
        <p>Material: <span>${item.material}</span></p>
        ${isOwner == true ? btnsTemplate(item._id,onDelete) : ''}
    </div>
</div>
`;
const btnsTemplate = (id,onDelete) => html`
<div>
    <a href=${`/edit/${id}`} class="btn btn-info">Edit</a>
    <a href="/" @click=${onDelete} class="btn btn-red">Delete</a>
</div>
`;

export async function detailsPage(ctx) {
    const itemId = ctx.params.id;
    const itemData = await getFurnitureDetails(itemId);
    const owner = itemData._ownerId;
    const userId = sessionStorage.getItem('userId');
    const isOwner = owner == userId;
    
    ctx.render(detailsTemplate(itemData,isOwner,onDelete));

    async function onDelete() {
        await deleteFurniture(itemId);
    }
}