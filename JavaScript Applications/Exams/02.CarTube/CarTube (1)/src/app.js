import page from '../node_modules/page/page.mjs';
import {render} from '../node_modules/lit-html/lit-html.js';

import {homePage} from './views/home.js'
import {createPage} from './views/create.js'
import {editPage} from './views/edit.js'
import {detailsPage} from './views/details.js'
import {myListingPage} from './views/myListing.js'
import {catalogPage} from './views/catalog.js'
import {loginPage} from './views/login.js'
import {registerPage} from './views/register.js'
import {logout as apiLogout} from './api/api.js'

const main = document.getElementById('site-content');

document.getElementById('logoutBtn').addEventListener('click',logout);

page('/',decoreateContext,homePage);
page('/create',decoreateContext,createPage);
page('/details/:id',decoreateContext,detailsPage);
page('/edit/:id',decoreateContext,editPage);
page('/my-list',decoreateContext,myListingPage);
page('/catalog',decoreateContext,catalogPage);
page('/login',decoreateContext,loginPage);
page('/register',decoreateContext,registerPage);


page.start();

function decoreateContext(ctx,next){
    ctx.render = (content) => render(content,main);
    ctx.updateNav = setUserNav;
    next();
}

setUserNav();
function setUserNav() {
    const token = sessionStorage.getItem('userToken');
    const username = sessionStorage.getItem('username');
    document.getElementById('welcome-username').textContent = `Welcome ${username}`;
    if (token) {
        document.getElementById('profile').style.display = 'block';
        document.getElementById('guest').style.display = 'none';
    } else {
        document.getElementById('profile').style.display = 'none';
        document.getElementById('guest').style.display = 'block';
    }
}

async function logout() {
    await apiLogout();
    setUserNav();
    page.redirect('/');
}