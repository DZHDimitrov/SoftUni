import {showHome} from './home.js'
import {createMovieBtn} from './common.js'

async function onSubmit(data) {
    if (!data.email || !data.password) {
        return alert('All fields are required!')
    }
    const body = JSON.stringify({
        email:data.email,
        password: data.password,
    });

    const response = await fetch('http://localhost:3030/users/login',{
        method: 'post',
        headers: {'Content-Type':'application/json'},
        body
    });
    const responseData = await response.json();
    if (response.status == 200) {
        const token = responseData.accessToken;
        const email = responseData.email;
        const userId = responseData._id;

        localStorage.setItem('userToken',token);
        localStorage.setItem('userEmail',email);
        localStorage.setItem('userId',userId);

        [...document.querySelectorAll('nav li.user')].forEach(x=>x.style.display = 'block');
        [...document.querySelectorAll('nav li.guest')].forEach(x=>x.style.display = 'none');
        document.getElementById('welcomeLink').textContent = `Welcome, ${email}`;
        createMovieBtn.style.display = 'inline-block';

        showHome();

    }else {
        console.error(responseData.message);
    }
}


let body;
let section;

export function setupLogin(bodyTarget,sectionTarget) {
    body = bodyTarget;
    section = sectionTarget;

    const form = section.querySelector('form');
    form.addEventListener('submit',(e) => {
        e.preventDefault();
        const formData = new FormData(e.target);
        onSubmit([...formData.entries()].reduce((p,[k,v]) => Object.assign(p,{[k]:v}),{}));
    });
}

export function showLogin() {
    [...body.querySelectorAll('section')].forEach(x=> x.remove());
    document.querySelector('nav').insertAdjacentElement('afterend',section);
}