import {html} from '../../node_modules/lit-html/lit-html.js';
import {register} from '../api/api.js';

const registerTemplate = (onSubmit,isValid) => html`
<section id="register">
    <article class="narrow">
        <header class="pad-med">
            <h1>Register</h1>
        </header>
        <form id="register-form" class="main-form pad-large" @submit=${onSubmit}>
            ${isValid == false ? html`<div class="error">Error message.</div>` : ''}
            <label>E-mail: <input type="text" name="email"></label>
            <label>Username: <input type="text" name="username"></label>
            <label>Password: <input type="password" name="password"></label>
            <label>Repeat: <input type="password" name="repass"></label>
            <input class="action cta" type="submit" value="Create Account">
        </form>
        <footer class="pad-small">Already have an account? <a href="#" class="invert">Sign in here</a>
        </footer>
    </article>
</section>
`;

export async function registerPage(ctx){
    ctx.render(registerTemplate(onSubmit,true));

    async function onSubmit(event){
        event.preventDefault();
        const formData = new FormData(event.currentTarget);
        const email = formData.get('email');
        const username = formData.get('username');
        const password = formData.get('password');
        const repeatPassword = formData.get('repass');

        if (email == '' || username.length < 3 || password.length < 3 || password != repeatPassword) {
            console.log(ctx);
            return ctx.render(registerTemplate(onSubmit,false))
        }

        await register(email,username,password);
        ctx.render(registerTemplate(onSubmit,true));
        ctx.page.redirect('/');
        ctx.updateNavigation();
    }
}