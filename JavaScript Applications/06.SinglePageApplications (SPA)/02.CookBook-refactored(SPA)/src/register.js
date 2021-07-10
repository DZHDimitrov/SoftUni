import {showCatalog} from './catalog.js'
async function onRegisterSubmit(data) {
    if (data.password !== data.rePass) {
        return console.Error('Passwords don\'t match')
    }
    const body = JSON.stringify({
        email: data.email,
        password: data.password,
    });

    try {
        const response = await fetch('http://localhost:3030/users/register', {
            method: 'post',
            headers: { 'Content-Type': 'appliction/json' },
            body,
        });

        const currentData = await response.json();
        if (response.status == 200) {
            sessionStorage.setItem('userToken', currentData.accessToken);
            sessionStorage.setItem('userId', currentData._id);
            sessionStorage.setItem('email', currentData.email);

            document.getElementById('user').style.display = 'inline-block';
            document.getElementById('guest').style.display = 'none';
            
            showCatalog();
        } else {
            throw new Error(data.message);
        } 
    }
    catch (error) {
        console.error(error.message)
    }
}

let main;
let section;
let setActiveNav;

export function setupRegister(mainTarget, sectionTarget,setActiveNavCb) {
    
    main = mainTarget;
    section = sectionTarget;
    setActiveNav = setActiveNavCb;
    section.querySelector('form').addEventListener('submit', (ev => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        onRegisterSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
    }));
}

export function showRegister() {
    setActiveNav('registerLink');
    main.innerHTML = '';
    main.appendChild(section);
}