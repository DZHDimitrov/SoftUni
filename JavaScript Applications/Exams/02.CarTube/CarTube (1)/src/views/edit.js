import {html} from '../../node_modules/lit-html/lit-html.js';
import {getCarById,updateCarById} from '../api/data.js';

const editTemplate = (car,onSubmit) => html`
<section id="edit-listing">
    <div class="container">
        <form id="edit-form" @submit=${onSubmit}>
            <h1>Edit Car Listing</h1>
            <p>Please fill in this form to edit an listing.</p>
            <hr>
            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand" .value=${car.brand}>

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model" .value=${car.model}>

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description" .value=${car.description}>

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year" .value=${car.year}>

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl" .value=${car.imageUrl}>

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price" .value=${car.price}>

            <hr>
            <input type="submit" class="registerbtn" value="Edit Listing">
        </form>
    </div>
</section>
`;
export async function editPage(ctx){
    const carId = ctx.params.id;
    const car = await getCarById(carId);
    ctx.render(editTemplate(car,onSubmit));

    async function onSubmit(event){
        event.preventDefault();
        if ([...event.currentTarget.querySelectorAll('input')].some(x=>x.value == '')) {
            return alert('All fields are required!');
        }
        
        const formData = new FormData(event.currentTarget);
        const data = {
            brand: formData.get('brand'),
            description: formData.get('description'),
            imageUrl: formData.get('imageUrl'),
            model: formData.get('model'),
            price: Number(formData.get('price')),
            year: Number(formData.get('year')),
        }
        
        await updateCarById(carId,data);
        ctx.page.redirect(`/details/${carId}`);
    }
}