import {html} from '../../node_modules/lit-html/lit-html.js';
import {getMyCars} from '../api/data.js';

const myListingsTemplate = (cars) => html`
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">
        ${cars.length > 0 ? cars.map(singleCarTemplate) : html` <p class="no-cars"> You haven't listed any cars yet.</p>`}
    </div>
</section>
`;

const singleCarTemplate = (car) => html`
<div class="listing">
    <div class="preview">
        <img src=${car.imageUrl}>
    </div>
    <h2>Audi A3</h2>
    <div class="info">
        <div class="data-info">
            <h3>Year: ${car.year}</h3>
            <h3>Price: ${car.price} $</h3>
        </div>
        <div class="data-buttons">
            <a href="/details/${car._id}" class="button-carDetails">Details</a>
        </div>
    </div>
</div>
`;

export async function myListingPage(ctx) {
    const userId = sessionStorage.getItem('userId');
    const userCars = await getMyCars(userId);

    ctx.render(myListingsTemplate(userCars));
}