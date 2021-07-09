document.getElementById('loginForm').addEventListener('submit', login)
async function login(e) {
    e.preventDefault();
    const form = e.target;
    const formData = new FormData(form);

    const email = formData.get('email');
    const password = formData.get('password');

    const obj = {
        email,
        password,
    }
    const url = 'http://localhost:3030/users/login';
    //AJAX Request Login - POST
    const response = await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(obj),
    })

    if (response.ok) {
        const data = await response.json();
        console.log(data);
        sessionStorage.setItem('userToken', data.accessToken);
        sessionStorage.setItem('userId',data._id)
        window.location.pathname = '05.Fisher-Game/index.html';
    }else {

        const spanElement = document.createElement('span');
        setTimeout(() => { spanElement.style.display= 'none' }, 3000);
        spanElement.textContent = 'Invalid username or password!'
        spanElement.style.color = 'red';
        form.appendChild(spanElement);
    }
    
}