async function onLoginSubmit(data) {
    const body = JSON.stringify({
        email: data.email,
        password: data.password,
    });

    try {
        const response = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: { 'Content-Type': 'appliction/json' },
            body,
        });

        const currentData = await response.json();
        if (response.status == 200) {
            sessionStorage.setItem('userToken', currentData.accessToken);
            onSuccess();
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
let onSuccess;

export function setupLogin(mainTarget, sectionTarget,onSuccessTarget) {
    main = mainTarget;
    section = sectionTarget;
    onSuccess = onSuccessTarget;
    section.querySelector('form').addEventListener('submit', (ev => {
        ev.preventDefault();
        const formData = new FormData(ev.target);
        onLoginSubmit([...formData.entries()].reduce((p, [k, v]) => Object.assign(p, { [k]: v }), {}));
    }));
}

export function showLogin() {
    main.innerHTML = '';
    main.appendChild(section);
}