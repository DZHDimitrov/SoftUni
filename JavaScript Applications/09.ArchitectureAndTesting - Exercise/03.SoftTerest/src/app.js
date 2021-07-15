import {setHome} from './views/home.js'
import {setDashboard} from './views/dashboard.js'
import {setRegister} from './views/register.js'
import {setLogin} from './views/login.js'
import {setCreate} from './views/create.js'
import {setDetails} from './views/details.js'
import {logout} from './api/data.js';

const main = document.querySelector('main');
const nav  = document.querySelector('nav');
const links = {};
const views = {};

const navigation = {
    changeView,
    setUserNav,
};

registerView('home',document.getElementById('homePage'),setHome,'homeLink');
registerView('dashboard',document.getElementById('dashboard-holder'),setDashboard,'dashboardLink');
registerView('login',document.getElementById('loginPage'),setLogin,'loginLink');
registerView('register',document.getElementById('registerPage'),setRegister,'registerLink');
registerView('create',document.getElementById('createPage'),setCreate,'createLink');
registerView('details',document.getElementById('detailsPage'),setDetails);
document.getElementById('views').remove();

setupNavigation();

changeView('home');

function registerView(name,sectionId,setup,linkId){;
    const view = setup(sectionId,navigation);
    views[name] = view;
    if (linkId) {
        links[linkId] = name;
    }
    
}

async function changeView(name,...params){
    main.innerHTML = '';
    const view = views[name];
    const section = await view(...params);
    main.appendChild(section);
}

function setupNavigation() {
    setUserNav();
    nav.addEventListener('click', ev => {
        const viewName = links[ev.target.id];
        if (viewName) {
            ev.preventDefault();
            changeView(viewName);
        } else if (ev.target.id == 'logoutBtn'){
            ev.preventDefault();
            (async ()=> {
                await logout();
                setUserNav();
            })();
        }
    });
}

function setUserNav() {
    const token = sessionStorage.getItem('authToken');
    
    if (token != null) {
        [...nav.querySelectorAll('.user')].forEach(x=> x.style.display = 'list-item');
        [...nav.querySelectorAll('.guest')].forEach(x=> x.style.display = 'none');
    } else {
        [...nav.querySelectorAll('.user')].forEach(x=> x.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(x=> x.style.display = 'list-item');
    }
}