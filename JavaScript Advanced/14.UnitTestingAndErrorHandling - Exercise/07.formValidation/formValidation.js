function validate() {
    const usernameElement = document.getElementById('username');
    const emailElement = document.getElementById('email');
    const passwordElement = document.getElementById('password');
    const confirmPasswordElement = document.getElementById('confirm-password');
    const companyElement = document.getElementById('company');
    const companyInfo = document.getElementById('companyInfo');
    const companyNumber = document.getElementById('companyNumber');
    const validElement = document.getElementById('valid');
    const btnElement = document.getElementById('submit');
    btnElement.addEventListener('click', doValidation)
    companyElement.addEventListener('change', () => {
        console.log(companyElement.checked);
        if (!companyElement.checked) {
            companyInfo.style.display = 'none';
        } else {
            companyInfo.style.display = 'block';
        }

        companyNumber.addEventListener('change', () => {
            const number = Number(companyNumber.value);
            if (number < 1000 || number > 9999 || !Number.isInteger(number)) {
                companyNumber.style.borderColor = 'red';
            } else {
                companyNumber.style.borderColor = '';
            };
        });

    })
    function doValidation(ev) {
        ev.preventDefault();
        const username = usernameElement.value;
        console.log(username);
        if (!/^[A-Za-z0-9]{3,}$/g.test(username)) {
            usernameElement.style.borderColor = 'red';
            throw new Error('Invalid username');
        } else {
            usernameElement.style.borderColor = 'none';
        }
        const email = emailElement.value;
        if (!/^\w+@\w+.?\w+(?:\.\w+){0,5}$/g.test(email)) {
            emailElement.style.borderColor = 'red';
            throw new Error('Invalid email');
        } else {
            emailElement.style.borderColor = 'none';
        }
        const password = passwordElement.value;
        if (!/^\w{5,15}$/g.test(password)) {
            passwordElement.style.borderColor = 'red';
            throw new Error('Invalid password');
        } else {
            passwordElement.style.borderColor = 'none';
        }
        const confirmPassword = confirmPasswordElement.value;
        if (!/^\w{5,15}$/g.test(confirmPassword) || password != confirmPassword) {
            console.log(password,confirmPassword);
            passwordElement.style.borderColor = 'red';
            throw new Error('Passwords must match');
        } else {
            passwordElement.style.borderColor = 'none';
        }

        validElement.style.display = 'block';
    }
}
