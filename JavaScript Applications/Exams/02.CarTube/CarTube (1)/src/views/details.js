import {html} from '../../node_modules/lit-html/lit-html.js';
import {getCarById,deleteCarById} from '../api/data.js';

const detailsTemplate = (car,isOwner,onDelete) => html`
<section id="listing-details">
    <h1>Details</h1>
    <div class="details-info">
        <img src=${car.imageUrl}>
        <hr>
        <ul class="listing-props">
            <li><span>Brand:</span>${car.brand}</li>
            <li><span>Model:</span>${car.model}</li>
            <li><span>Year:</span>${car.year}</li>
            <li><span>Price:</span>${car.price}$</li>
        </ul>

        <p class="description-para">Some description of this car. Lorem ipsum dolor sit amet consectetur
            adipisicing elit. Sunt voluptate quam nesciunt ipsa veritatis voluptas optio debitis repellat porro
            sapiente.</p>
        ${isOwner ? html`<div class="listings-buttons">  
            <a href="/edit/${car._id}" class="button-list">Edit</a>
            <a href="javascript:void(0)" class="button-list" @click=${onDelete}>Delete</a>
        </div>` : ''}
        
    </div>
</section>
`;
export async function detailsPage(ctx){
    const carId = ctx.params.id;
    const userId = sessionStorage.getItem('userId');
    const car = await getCarById(carId);
    ctx.render(detailsTemplate(car,userId == car._ownerId,onDelete));

    async function onDelete(){
        await deleteCarById(carId);
        ctx.page.redirect('/catalog');
    }
}