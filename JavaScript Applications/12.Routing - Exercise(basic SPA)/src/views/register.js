import {html} from '../../node_modules/lit-html/lit-html.js';
import {register} from '../api/data.js';

const registerTemplate = (validation,onSubmit) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class="form-control id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class="form-control" id="password" type="password" name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class="form-control" id="rePass" type="password" name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>
`;

export async function registerPage(ctx) {

    ctx.render(registerTemplate({},onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);

        const email = formData.get('email');
        const password = formData.get('password');
        const repeatPassword = formData.get('rePass');

        if (email == '' || password == '' || repeatPassword == '') {
            return alert('All fields are required!')
        }

        if (password !== repeatPassword) {
            return alert('Passwords don\'t match!') 
        }

        await register(email,password);
        ctx.setUserNav();
        ctx.page.redirect('/');
    }
}