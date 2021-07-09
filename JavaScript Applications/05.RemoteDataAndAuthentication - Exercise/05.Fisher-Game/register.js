import { ce } from './dom.js'

document.getElementById('registerForm').addEventListener('submit', register)

async function register(e) {
    e.preventDefault();
    const form = e.target;
    const formData = new FormData(form);

    const email = formData.get('email');
    const password = formData.get('password');
    const confirmPassword = formData.get('rePass');
    if (form.querySelector('span')) {
        form.lastElementChild.remove();
    }
    if (!email) {
        const spanElement = ce('span',{style:'color:red'},'Invalid email!')
        form.appendChild(spanElement);
        return;
    } else if (!password) {
        const spanElement = ce('span',{style:'color:red'},'Invalid password!')
        form.appendChild(spanElement);
        return;
    } else if (password !== confirmPassword) {
        const spanElement = ce('span',{style:'color:red'},'Passwords don\'t match!')
        form.appendChild(spanElement);
        return;
    }

    const obj = {
        email,
        password,
    }

    const url = 'http://localhost:3030/users/register';

    //AJAX Request Login - POST
    const response = await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(obj),
    })

    const data = await response.json();
    if (response.ok) {
        console.log(data);
        sessionStorage.setItem('userToken', data.accessToken);
        sessionStorage.setItem('userId',data._id)
        window.location.pathname = '05.Fisher-Game/index.html';
    }else {
        const spanElement = document.createElement('span');
        setTimeout(() => { spanElement.style.display= 'none' }, 3000);
        spanElement.textContent = `${data.message}`
        spanElement.style.color = 'red';
        form.appendChild(spanElement);
    }
    
}