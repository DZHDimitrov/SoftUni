function start() {
    const submitForm = document.getElementById('submitForm');
    const editForm = document.getElementById('editForm')
    const resultTable = document.querySelector('body table tbody');

    [...resultTable.children].forEach(x => x.remove());

    document.getElementById('loadBooks').addEventListener('click', loadBooks);
    submitForm.addEventListener('submit',onSubmit);
    editForm.addEventListener('submit',onEdit);

    async function loadBooks() {
        [...resultTable.children].forEach(x => x.remove());
        const url = 'http://localhost:3030/jsonstore/collections/books';

        //AJAX Request GET
        const response = await fetch(url);
        const data = await response.json();

        Object.entries(data).forEach(([key, value]) => {
            const row = document.createElement('tr');
            row.dataset.id = key;
            row.appendChild(createTrElements(value));
            resultTable.appendChild(row);
        })
    }

    async function onEdit(e) {
        e.preventDefault();
        const form = e.target;
        const formData = new FormData(form);
        const title = formData.get('title');
        const author = formData.get('author');
        const bookId = formData.get('bookId');
        
        if (!title || !author) {
            return;
        }

        const obj = {
            title,
            author,
        }
        
        form.reset();
        const url = `http://localhost:3030/jsonstore/collections/books/${bookId}`;

        //AJAX Request PUT
        const response = await fetch(url,{
            method:'PUT',
            headers: {'Content-Type':'application/json'},
            body:JSON.stringify(obj)
        });
        
        const tr = Array.from(document.querySelectorAll('body tbody tr')).find(x=>x.dataset.id == bookId);
        tr.firstElementChild.textContent = title;
        tr.firstElementChild.nextElementSibling.textContent = author;

        editForm.style.display = 'none';
        submitForm.style.display = 'block';
    }

    async function onSubmit(e) {
        e.preventDefault();
        const form = e.target;
        const formData = new FormData(form);
        const title = formData.get('title');
        const author = formData.get('author');
        
        if (!title || !author) {
            return;
        }

        const obj = {
            title,
            author,
        }
        
        form.reset();
        const url = 'http://localhost:3030/jsonstore/collections/books';

        //AJAX Request POST
        const response = await fetch(url,{
            method:'POST',
            headers: {'Content-Type':'application/json'},
            body:JSON.stringify(obj)
        });

        const data = await response.json();
        if (resultTable.children.length > 0) {
            const tr = document.createElement('tr');
            tr.dataset.id = data._id;
            tr.appendChild(createTrElements(obj));
            resultTable.appendChild(tr);
        }
    }

    function createTrElements(value) {
        const fragment = document.createDocumentFragment();

        const authorTd = document.createElement('td');
        authorTd.textContent = value.title;
        const titleTd = document.createElement('td');
        titleTd.textContent = value.author;
        const buttonTd = document.createElement('td');
        const editBtn = document.createElement('button');
        editBtn.textContent = 'Edit';
        editBtn.addEventListener('click',(e) => {
            const row = e.target.parentElement.parentElement;
            submitForm.style.display = 'none';
            editForm.style.display = 'block';
            const author = e.target.parentElement.previousElementSibling.textContent;
            const title = row.firstElementChild.textContent;
            editForm.querySelector('input[name="title"]').value = title;
            editForm.querySelector('input[name="author"]').value = author;
            editForm.querySelector('input[name="bookId"]').value = row.dataset.id;
        });
        const deleteBtn = document.createElement('button');
        deleteBtn.textContent = 'Delete';

        deleteBtn.addEventListener('click',async (e) => {

            
            const row = e.target.parentElement.parentElement;
            const bookId = row.dataset.id;
            const url = `http://localhost:3030/jsonstore/collections/books/${bookId}`;

            //AJAX Request DELETE
            const response = await fetch(url,{
                method: 'DELETE',
            });
            row.remove();
        })
        buttonTd.append(editBtn,deleteBtn);

        fragment.append(authorTd,titleTd,buttonTd);
        return fragment;
    };
}
start();