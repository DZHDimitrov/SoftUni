function start() {
    document.getElementById('form').addEventListener('submit',onSubmit);
    const resultElement = document.querySelector('#results tbody');
    loadStudents();

    //Unrequired
    async function loadStudents() {
        const url = 'http://localhost:3030/jsonstore/collections/students';
        
        //AJAX Request
        const response = await fetch(url);
        const data = await response.json();

        const fragment = document.createDocumentFragment();
        [...Object.values(data)].forEach(x=> {
            const trElement = document.createElement('tr');
            Object.values(x).forEach((y,i)=> {
                if (i <= 3) {
                const tdElement = document.createElement('td');
                tdElement.textContent = y;
                trElement.appendChild(tdElement);
                }
            });
            fragment.appendChild(trElement);
        });
        resultElement.appendChild(fragment);

    }
    async function onSubmit(e){
        e.preventDefault();
        const form = e.target;
        const formData = new FormData(form);

        const firstName = formData.get('firstName');
        const lastName = formData.get('lastName');
        const facultyNumber = formData.get('facultyNumber');
        const grade = Number(formData.get('grade'));

        if (!firstName || !lastName || !facultyNumber || !grade) {
            return;
        }

        const obj = {
            firstName,
            lastName,
            facultyNumber,
            grade,
        }

        form.reset();
        const url = 'http://localhost:3030/jsonstore/collections/students';

        //AJAX Request
        const response = await fetch(url,{
            method:'POST',
            headers:{'Content-Type':'application/json'},
            body:JSON.stringify(obj),
        });

        const trElement = document.createElement('tr');
        Object.values(obj).forEach(el => {
            const tdElement = document.createElement('td');
            tdElement.textContent = el;
            trElement.appendChild(tdElement);
        });
        resultElement.appendChild(trElement);
    }
}

start();