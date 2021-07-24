import page from '../node_modules/page/page.mjs';
import {render} from '../node_modules/lit-html/lit-html.js';
import {logout as logoutAPI} from './api/api.js'


import {homePage} from './views/home.js';
import {registerPage} from './views/register.js';
import {loginPage} from './views/login.js';
import {browseTeamsPage} from './views/browseTeams.js';
import {createPage} from './views/create.js';
import {detailsPage} from './views/details.js';
import {editPage} from './views/edit.js';
import { myTeamsPage } from './views/myTeams.js';

const main = document.querySelector('main');
const nav = document.querySelector('nav');
document.getElementById('logoutBtn').addEventListener('click',logout);

page('/',decorateContext, homePage);
page('/register',decorateContext,registerPage);
page('/login',decorateContext,loginPage);
page('/browse',decorateContext,browseTeamsPage);
page('/create',decorateContext,createPage);
page('/details/:id',decorateContext,detailsPage);
page('/edit/:id',decorateContext,editPage);
page('/my-teams',decorateContext,myTeamsPage);

page.start();
setUserNav();

function decorateContext(ctx,next) {
    ctx.render = (content) => render(content,main);
    ctx.userToken = sessionStorage.getItem('userToken');
    ctx.userId = sessionStorage.getItem('userId');
    ctx.updateNavigation = () => setUserNav();
    next();
}

function setUserNav(){
    const token = sessionStorage.getItem('userToken');

    if (token) {
        [...nav.querySelectorAll('a')].filter(x=> x.classList.contains('guest')).forEach(x=>x.style.display = 'none');
        [...nav.querySelectorAll('a')].filter(x=> x.classList.contains('user')).forEach(x=>x.style.display = 'block');
    } else {
        [...nav.querySelectorAll('a')].filter(x=> x.classList.contains('guest')).forEach(x=>x.style.display = 'block');
        [...nav.querySelectorAll('a')].filter(x=> x.classList.contains('user')).forEach(x=>x.style.display = 'none');
    }
}

async function logout() {
    await logoutAPI();
    setUserNav();
    page.redirect('/');
}
