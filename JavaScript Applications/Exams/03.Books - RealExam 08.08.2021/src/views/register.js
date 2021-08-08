import { html } from '../../node_modules/lit-html/lit-html.js';

import {register} from '../api/data.js';

const registerTemplate = (onSubmit) => html`
<!-- Register Page ( Only for Guest users ) -->
<section id="register-page" class="register">
    <form id="register-form" action="" method="" @submit=${onSubmit}>
        <fieldset>
            <legend>Register Form</legend>
            <p class="field">
                <label for="email">Email</label>
                <span class="input">
                    <input type="text" name="email" id="email" placeholder="Email">
                </span>
            </p>
            <p class="field">
                <label for="password">Password</label>
                <span class="input">
                    <input type="password" name="password" id="password" placeholder="Password">
                </span>
            </p>
            <p class="field">
                <label for="repeat-pass">Repeat Password</label>
                <span class="input">
                    <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                </span>
            </p>
            <input class="button submit" type="submit" value="Register">
        </fieldset>
    </form>
</section>
`;

export async function registerPage(ctx) {
    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.currentTarget);
        const email = formData.get('email');
        const password = formData.get('password');
        const confirmPassword = formData.get('confirm-pass');
        
        try {
            if (!email || !password || !confirmPassword) {
                throw new Error('All fields are required!')
            }
            if (password != confirmPassword) {
                throw new Error('Passwords dont\'t match')
            }
            await register(email,password);
            ctx.page.redirect('/all');
            ctx.setUserNav();

        } catch (error) {
            alert(error.message);
        }
    }
}