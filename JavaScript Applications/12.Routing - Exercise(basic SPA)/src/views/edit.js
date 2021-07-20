import {html} from '../../node_modules/lit-html/lit-html.js';
import {getFurnitureDetails,updateFurniture} from '../api/data.js';

const editTemplate = (item,onSubmit,validation,isEmpty) => html `
 <div class="row space-top">
    <div class="col-md-12">
        <h1>Edit Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
    <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class=${'form-control valid' + (isEmpty == true ? '' : (validation.makeValid == true ? ' is-valid' : ' is-invalid'))}  id="new-make" type="text" name="make" .value=${item.make}>
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class=${'form-control' + (isEmpty == true ? '' : (validation.modelValid == true ? ' is-valid' : ' is-invalid'))} id="new-model" type="text" name="model" .value=${item.model}>
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class=${'form-control' + (isEmpty == true ? '' : (validation.yearValid == true ? ' is-valid' : ' is-invalid'))} id="new-year" type="number" name="year" .value=${item.year}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class=${'form-control' + (isEmpty == true ? '' : (validation.descriptionValid == true ? ' is-valid' : ' is-invalid'))} id="new-description" type="text" name="description" .value=${item.description}>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class=${'form-control' + (isEmpty == true ? '' : (validation.priceValid == true ? ' is-valid' : ' is-invalid'))} id="new-price" type="number" name="price" .value=${item.price}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class=${'form-control valid' + (isEmpty == true ? '' : (validation.imageValid == true ? ' is-valid' : ' is-invalid'))} id="new-image" type="text" name="img" .value=${item.img}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material">
            </div>
            <input type="submit" class="btn btn-primary" value="Edit" />
        </div>
    </div>
</form>
`;

export async function editPage(ctx){
    const id = ctx.params.id;
    const details = await getFurnitureDetails(id);

    ctx.render(editTemplate(details,onSubmit,{},true));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.currentTarget);
        
        const make = formData.get('make');
        const year = formData.get('year');
        const model = formData.get('model');
        const description = formData.get('description');
        const price = formData.get('price');
        const img = formData.get('img');
        const material = formData.get('material');
        console.log(make);
        const makeValid = make.length < 4 ? false : true;
        const modelValid = model.length < 4 ? false : true;
        const yearValid = (year >= 1950 && year <= 2050) ? true : false;
        const descriptionValid = description <= 10 ? false : true;
        const priceValid = price <= 0 ? false : true;
        const imageValid = img == '' ? false : true;

        const validation = {
            makeValid,
            modelValid,
            yearValid,
            descriptionValid,
            priceValid,
            imageValid,
        }

        if (Object.values(validation).some(x=>x == false)) {
            return ctx.render(editTemplate(details,onSubmit,validation,false));
        }

        await updateFurniture(id,{make,model,year,description,price,img,material});
        ctx.page.redirect('/');
    }
}