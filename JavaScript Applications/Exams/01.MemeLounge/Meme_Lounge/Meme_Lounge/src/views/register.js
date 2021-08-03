import { html } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../api/api.js'
import { notify } from '../views/notification.js';

const registerTemplate = (onSubmit) => html`
<section id="register">
    <form id="register-form" @submit=${onSubmit}>
        <div class="container">
            <h1>Register</h1>
            <label for="username">Username</label>
            <input id="username" type="text" placeholder="Enter Username" name="username">
            <label for="email">Email</label>
            <input id="email" type="text" placeholder="Enter Email" name="email">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <label for="repeatPass">Repeat Password</label>
            <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
            <div class="gender">
                <input type="radio" name="gender" id="female" value="female">
                <label for="female">Female</label>
                <input type="radio" name="gender" id="male" value="male">
                <label for="male">Male</label>
            </div>
            <input type="submit" class="registerbtn button" value="Register">
            <div class="container signin">
                <p>Already have an account?<a href="#">Sign in</a>.</p>
            </div>
        </div>
    </form>
</section>
`;

export async function registerPage(ctx) {
    ctx.render(registerTemplate(onSubmit))

    async function onSubmit(event) {
        event.preventDefault();

        const formData = new FormData(event.currentTarget);
        const username = formData.get('username');
        const email = formData.get('email');
        const password = formData.get('password');
        const repeatPassword = formData.get('repeatPass')
        const gender = formData.get('gender');

        try {
            if (!username || !email || !password || !gender || !repeatPassword) {
                throw new Error('All fields are required!')
            }
            if (password !== repeatPassword) {
                throw new Error('Passwords don\'t match!')
            }

            await register(username, email, password, gender);
            ctx.updateNav();
            ctx.page.redirect('/catalog');
        } catch (error) {
            notify(error.message);
        }
    }
}