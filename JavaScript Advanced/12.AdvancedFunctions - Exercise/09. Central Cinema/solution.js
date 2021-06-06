function solve() {
    const formElements = Array.from(document.querySelector('#container').children);
    const inputs = formElements.slice(0, formElements.length - 1);
    const onScreenBtn = formElements.slice(formElements.length - 1)[0];
    const movies = document.querySelector('#movies ul');
    const archive = document.querySelector('#archive ul');
    const clear = document.querySelector('#archive button');

    function clearUl() {
        Array.from(archive.children).map(x => archive.removeChild(x));
    }
    function archiveFunc(ev) {
        const name = ev.target.parentNode.parentNode.firstElementChild.textContent;
        const price = Number(ev.target.parentNode.firstElementChild.textContent);
        const count = Number(ev.target.parentNode.firstElementChild.nextElementSibling.value);
        let parent = ev.target.parentNode.parentNode;
        if (count) {
            parent.remove(parent.lastElemetnChild);
            let liElement = document.createElement('li');
            let spanElement = document.createElement('span');
            spanElement.textContent = name;
            let strongElement = document.createElement('strong');
            let result = price * count
            strongElement.textContent = `Total amount: ${result.toFixed(2)}`;
            let btnElement = document.createElement('button');
            btnElement.textContent = 'Delete';
            btnElement.addEventListener('click', del);

            liElement.appendChild(spanElement);
            liElement.appendChild(strongElement);
            liElement.appendChild(btnElement);

            archive.appendChild(liElement);
        }


    }
    function del(e) {
        archive.removeChild(e.target.parentNode);
    }
    function createMovie(e) {
        e.preventDefault();

        const name = inputs[0].value;
        const hall = inputs[1].value;
        const price = Number(inputs[2].value);

        inputs[0].value = '';
        inputs[1].value = '';
        inputs[2].value = '';

        if (!name || !hall || !price) {
            return;
        }

        const li = document.createElement('li');
        const span = document.createElement('span');
        span.textContent = name;
        li.appendChild(span);
        const strong = document.createElement('strong');
        strong.textContent = `Hall: ${hall}`;
        li.appendChild(strong);

        const div = document.createElement('div');
        const innerStrong = document.createElement('strong');
        innerStrong.textContent = price.toFixed(2);
        const input = document.createElement('input');
        input.placeholder = 'Tickets Sold'
        const archiveBtn = document.createElement('button');
        archiveBtn.textContent = 'Archive';
        archiveBtn.addEventListener('click', archiveFunc)

        div.appendChild(innerStrong);
        div.appendChild(input);
        div.appendChild(archiveBtn);

        li.appendChild(div);

        movies.appendChild(li);

    }

    onScreenBtn.addEventListener('click', createMovie)
    
    clear.addEventListener('click', clearUl);
}