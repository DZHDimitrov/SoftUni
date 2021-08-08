import {render} from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';
import { logout as apiLogout} from './api/data.js';

import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { createPage } from './views/create.js';
import { editPage } from './views/edit.js';
import {detailsPage} from './views/details.js';
import { allPage } from './views/all.js';
import { profilePage } from './views/profile.js';

document.getElementById('logoutBtn').addEventListener('click',logout);
const main = document.getElementById('site-content');

page('/create',decorateContext,createPage);
page('/edit/:id',decorateContext,editPage);
page('/details/:id',decorateContext,detailsPage);
page('/all',decorateContext,allPage);
page('/login',decorateContext,loginPage);
page('/register',decorateContext,registerPage);
page('/my-books',decorateContext,profilePage);

page.start();
setUserNav();

function decorateContext(ctx,next){
    ctx.render = (content) => render(content,main);
    ctx.userToken = sessionStorage.getItem('userToken');
    ctx.setUserNav = setUserNav;
    ctx.userId = sessionStorage.getItem('userId');
    next();
}

function setUserNav(){ 
    const token = sessionStorage.getItem('userToken');
    const email = sessionStorage.getItem('email');
    if (token) {
        document.getElementById('user').style.display = 'block';
        document.getElementById('guest').style.display = 'none';
        document.getElementById('welcomeMessage').textContent = `Welcome, ${email}`;
    }else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'block';
    }
}

async function logout() {
    await apiLogout();

    sessionStorage.removeItem('email');
    sessionStorage.removeItem('userToken');
    sessionStorage.removeItem('userId');
    setUserNav();

    page.redirect('/');
}

