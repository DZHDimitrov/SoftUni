import { setupCatalog, showCatalog } from './catalog.js'
import { setupLogin, showLogin } from './login.js'
import {setupRegister,showRegister} from './register.js'
import {setupCreate,showCreate} from './create.js'
import { setupDetails } from './details.js';
import { setupEdit } from './edit.js';

main();

function main() {

    setUserNav();

    const nav = document.querySelector('nav');
    const mainSection = document.querySelector('main');
    const catalogSection = document.getElementById('catalogSection');
    const loginSection = document.getElementById('loginSection');
    const registerSection = document.getElementById('registerSection');
    const createSection = document.getElementById('createSection');
    const detailsSection = document.getElementById('detailsSection');
    const editSection = document.getElementById('editSection');


    const links = {
        'catalogLink':showCatalog,
        'loginLink':showLogin,
        'registerLink':showRegister,
        'createLink':showCreate,
    }

    setupCatalog(mainSection, catalogSection,setActiveNav);
    setupLogin(mainSection, loginSection,setActiveNav);
    setupRegister(mainSection, registerSection,setActiveNav);
    setupCreate(mainSection, createSection,setActiveNav);
    setupDetails(mainSection, detailsSection,setActiveNav);
    setupEdit(mainSection, editSection,setActiveNav);

    showCatalog();

    setupNavigation();

    function setActiveNav(id) {
        [...nav.querySelectorAll('a')].forEach(l => {
            if (l.id == id) {
                l.classList.add('active')
            }else {
                l.classList.remove('active')
            }
        })
    }

    function setupNavigation() {
        document.getElementById('logoutBtn').addEventListener('click', logout);
        nav.addEventListener('click',(event) => {
            if (event.target.tagName == 'A') {
                const view = links[event.target.id];
                if (typeof view == 'function') {
                    event.preventDefault();
                    view();
                }
            }
        });
    }
}

function setUserNav() {
    const token = sessionStorage.getItem('userToken');
    if (token != null) {
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';
    } else {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }
}

async function logout() {
    const token = sessionStorage.getItem('userToken');
    await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: { 'X-Authorization': token }
    });
    sessionStorage.removeItem('userToken');
    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('email');
    setUserNav();
    showCatalog();
}
