import { setupLogin, showLogin } from './login.js'
import { setupRegister, showRegister } from './register.js'
import { setupHome, showHome } from './home.js'
import { setupCreate } from './createMovie.js'
import { setupDetails } from './details.js'
import { setupEdit } from './editMovie.js'

main();

function main() {

    const links = {
        'loginLink': showLogin,
        'registerLink': showRegister,
        'homeMovies': showHome,
        'welcomeLink': showHome,
    }

    const nav = document.querySelector('nav');
    const body = document.querySelector('body');
    const homeSection = document.getElementById('home-page');
    const loginSection = document.getElementById('form-login');
    const registerSection = document.getElementById('form-sign-up');
    const createSection = document.getElementById('add-movie');
    const detailsSection = document.getElementById('movie-details');
    const editSection = document.getElementById('edit-movie');

    setupHome(body, homeSection);
    setupLogin(body, loginSection);
    setupRegister(body, registerSection);
    setupCreate(body, createSection);
    setupDetails(body, detailsSection);
    setupEdit(body, editSection);

    setupNavigation();
    showHome();

    function setupNavigation() {
        if (localStorage.getItem('userToken')) {
            document.getElementById('welcomeLink').textContent = `Welcome, ${localStorage.getItem('userEmail')}`;

            [...nav.querySelectorAll('li')].forEach(x => {
                if (x.classList.contains('user')) {
                    x.style.display = 'block'
                }
            });
            [...nav.querySelectorAll('li.guest')].forEach(x => x.style.display = 'none');
        } else {
            [...nav.querySelectorAll('li')].forEach(x => {
                if (x.classList.contains('user')) {
                    x.style.display = 'none'
                }
            });
            [...nav.querySelectorAll('li.guest')].forEach(x => x.style.display = 'block');
        }
        nav.addEventListener('click', async (e) => {
            if (e.target.tagName == 'A' && e.target.id != 'logoutLink') {
                const view = links[e.target.id];
                console.log(e.target.id);
                if (typeof (view) == 'function') {
                    view();
                }
            }else if(e.target.id == 'logoutLink') {
                await logout();
                showHome();
                setupNavigation();
            }
        })
    }

    async function logout() {
        await fetch('http://localhost:3030/users/logout',{
            method: 'GET',
            headers: {'X-Authorization': localStorage.getItem('userToken')}
        });
        localStorage.removeItem('userId');
        localStorage.removeItem('userToken');
        localStorage.removeItem('userEmail');
    }
}