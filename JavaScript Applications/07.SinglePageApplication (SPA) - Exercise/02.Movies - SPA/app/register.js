import {showHome} from './home.js'
import {createMovieBtn} from './common.js'

let body;
let section;

async function onRegisterSubmit(event,data) {
    if (data.password != data.repeatPassword) {
        return alert('Password don\'t match! ')
    }
    if (!data.email || !data.password || !data.repeatPassword) {
        return alert('All fields are required!')
    }
    const body = JSON.stringify({
        email:data.email,
        password:data.password,
    });

    const response = await fetch('http://localhost:3030/users/register',{
        method: 'POST',
        headers: {'Content-Type':'application/json'},
        body
    });
    const responseData = await response.json();
    console.log(response.status);
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
        event.target.reset();
        showHome();

    }else {
        console.error(responseData.message);
    }
    
}

export function setupRegister(bodyTarget,sectionTarget) {
    body = bodyTarget;
    section = sectionTarget;

    section.querySelector('form').addEventListener('submit',(e) => {
        e.preventDefault();
        const form = e.target;
        const formData = new FormData(form);
        onRegisterSubmit(e,[...formData.entries()].reduce((p,[k,v]) => Object.assign(p,{[k]:v}),{}));
    })
}

export function showRegister() {
    [...body.querySelectorAll('section')].forEach(x=> x.remove());
    document.querySelector('nav').insertAdjacentElement('afterend',section);
}