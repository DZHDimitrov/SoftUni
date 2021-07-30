import {html} from '../../node_modules/lit-html/lit-html.js';
import {createCar} from '../api/data.js';

const createCarTemplate = (onSubmit) => html`
<!-- Create Listing Page -->
<section id="create-listing">
    <div class="container">
        <form id="create-form" @submit=${onSubmit}>
            <h1>Create Car Listing</h1>
            <p>Please fill in this form to create an listing.</p>
            <hr>

            <p>Car Brand</p>
            <input type="text" placeholder="Enter Car Brand" name="brand">

            <p>Car Model</p>
            <input type="text" placeholder="Enter Car Model" name="model">

            <p>Description</p>
            <input type="text" placeholder="Enter Description" name="description">

            <p>Car Year</p>
            <input type="number" placeholder="Enter Car Year" name="year">

            <p>Car Image</p>
            <input type="text" placeholder="Enter Car Image" name="imageUrl">

            <p>Car Price</p>
            <input type="number" placeholder="Enter Car Price" name="price">

            <hr>
            <input type="submit" class="registerbtn" value="Create Listing">
        </form>
    </div>
</section>
`;

export async function createPage(ctx) {
    ctx.render(createCarTemplate(onSubmit));

    async function onSubmit(event) {
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
        await createCar(data);
        ctx.page.redirect('/catalog');
    }
}