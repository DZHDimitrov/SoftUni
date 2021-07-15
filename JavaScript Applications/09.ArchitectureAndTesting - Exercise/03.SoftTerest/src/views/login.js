import {login} from '../api/data.js';

export function setLogin(section,navigation){ 
    section.addEventListener('submit',onSubmit);
    return showLogin;
    
    async function showLogin() {
        return section
    }

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);
        const email = formData.get('email');
        const password = formData.get('password');

        await login(email,password);

        navigation.changeView('home');
        navigation.setUserNav();
        event.target.reset();
    }
}