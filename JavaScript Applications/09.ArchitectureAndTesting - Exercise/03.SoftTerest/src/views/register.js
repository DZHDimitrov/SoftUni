import { register } from '../api/data.js'

export function setRegister(section,navigation){
    section.querySelector('form').addEventListener('submit',onSubmit);
    return showRegister;
    
    async function showRegister() {
        return section
    }

    async function onSubmit(event) {

        event.preventDefault();
        const formData = new FormData(event.target);

        const email = formData.get('email');
        const password = formData.get('password');
        const rePass = formData.get('repeatPassword');

        if (email.length < 3) {
            return alert('Email should be atleast 3 characters long.')
        }
        if (password.length < 3) {
            return alert('Password should be atleast 3 characters long.')
        }
        if (password !== rePass) {
            return alert('Passwords don\'t match!');
        }

        await register(email,password);
        navigation.changeView('home');
        navigation.setUserNav();
        event.target.reset();
    }
}