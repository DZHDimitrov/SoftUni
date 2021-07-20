import {html,render} from '../../node_modules/lit-html/lit-html.js';
import {getAllFurniture} from '../api/data.js';

const dashboardTemplate = (items) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Welcome to Furniture System</h1>
        <p>Select furniture from the catalog to view details.</p>
    </div>
</div>
<div class="row space-top">
    ${items.map(itemTemplate)}
</div>
`;
const itemTemplate = (item) => html`
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
                <img src=${item.img} />
                <p>Description here</p>
                <footer>
                    <p>Price: <span>${item.price} $</span></p>
                </footer>
                <div>
                    <a href=details/${item._id} class="btn btn-info">Details</a>
                </div>
        </div>
    </div>
</div>
`; 

export async function dashboardPage(ctx) {
    const allFurniture = await getAllFurniture();
    console.log(allFurniture);
    ctx.render(dashboardTemplate(allFurniture));
}
