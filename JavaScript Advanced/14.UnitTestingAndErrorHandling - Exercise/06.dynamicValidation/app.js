function validate() {
    const input = document.getElementById('email');

    input.addEventListener('change', () => {
        const email = input.value;
        if (!/^[a-z]+@[a-z]+.[a-z]+$/g.test(email)) {
            input.classList.add('error');
        } else {
            input.value = '';
            input.classList.remove('error');
        }
    });
};