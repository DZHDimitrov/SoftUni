import page from '../node_modules/page/page.mjs';
import {render} from '../node_modules/lit-html/lit-html.js';

import {homePage} from './views/home.js'
import {registerPage} from './views/register.js'
import {loginPage} from './views/login.js'
import {createPage} from './views/create.js'
import {detailsPage} from './views/details.js'
import {editPage} from './views/edit.js'
import {userProfilePage} from './views/profile.js'
import {memeFeedPage} from './views/meme-feed.js'
import {logout as apiLogout} from './api/data.js'

const main = document.querySelector('main');
const nav = document.querySelector('nav');

document.getElementById('logoutBtn').addEventListener('click',logout);

page('/',decorateContext,homePage)
page('/register',decorateContext,registerPage);
page('/login',decorateContext,loginPage);
page('/create',decorateContext,createPage);
page('/details/:id',decorateContext,detailsPage);
page('/edit/:id',decorateContext,editPage);
page('/my-profile',decorateContext,userProfilePage);
page('/catalog',decorateContext,memeFeedPage);


page.start();

setUserNav();
function decorateContext(ctx,next){
    ctx.render = (content) => render(content,main);
    ctx.updateNav = () => setUserNav();
    ctx.userId = sessionStorage.getItem('userId');
    ctx.gender = sessionStorage.getItem('gender');
    ctx.username = sessionStorage.getItem('username');
    ctx.email = sessionStorage.getItem('email');
    next();
}

function setUserNav(){
    const token = sessionStorage.getItem('userToken');
    if (token) {
        nav.querySelector('.user .profile span').textContent = `Welcome, ${sessionStorage.getItem('email')}`;
        document.querySelector('.user').style.display = '';
        document.querySelector('.guest').style.display = 'none';
    } else {
        document.querySelector('.user').style.display = 'none';
        document.querySelector('.guest').style.display = '';
    }
}

async function logout() {
    await apiLogout();
    sessionStorage.removeItem('userToken');
    sessionStorage.removeItem('email');
    sessionStorage.removeItem('userId');

    setUserNav();
    page.redirect('/');
}