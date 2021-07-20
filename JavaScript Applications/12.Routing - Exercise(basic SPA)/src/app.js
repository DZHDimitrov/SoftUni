import {render} from '../node_modules/lit-html/lit-html.js'
import page from '../node_modules/page/page.mjs';
import {logout} from './api/api.js';

import {createPage} from './views/create.js'
import {dashboardPage} from './views/dashboard.js'
import {detailsPage} from './views/details.js'
import {editPage} from './views/edit.js'
import {loginPage} from './views/login.js'
import {registerPage} from './views/register.js'
import {myFurniturePage} from './views/myFurniture.js'

const pageContainer = document.getElementById('container');
document.getElementById('logoutBtn').addEventListener('click',logoutFunc);

page('/',renderMiddleware,dashboardPage);
page('/create',renderMiddleware,createPage);
page('/register',renderMiddleware,registerPage);
page('/login',renderMiddleware,loginPage);
page('/details/:id',renderMiddleware,detailsPage);
page('/edit/:id',renderMiddleware,editPage);
page('/my-furniture',renderMiddleware,myFurniturePage);


function renderMiddleware(ctx,next){
    ctx.render = (content) => render(content,pageContainer);
    ctx.setUserNav = () => setUserNav();
    next(); 
}
setUserNav();
function setUserNav() {
    const token = sessionStorage.getItem('userToken');
    if (token) {
        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').style.display = 'inline-block';
    }else{
        document.getElementById('guest').style.display = 'inline-block';
        document.getElementById('user').style.display = 'none';
    }
}
async function logoutFunc() {
    await logout();
    setUserNav();
    page.redirect('/');
}

page.start();
