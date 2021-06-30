function solve() {
    const sections = document.querySelectorAll('section');
    const btnElement = document.getElementById('add');
    btnElement.addEventListener('click',add);

    function add(e) {
        e.preventDefault();
        const taskInput = document.getElementById('task');
        const descriptionTextArea = document.getElementById('description');
        const dueDate = document.getElementById('date');

        if (!taskInput.value || !descriptionTextArea.value || !dueDate.value) {
            return;
        }

        const openSection = sections[1];

        const title = taskInput.value;
        const description = descriptionTextArea.value;
        const date = dueDate.value;

        openSection.lastElementChild.appendChild(createArticle(title,description,date));

        
    }

    function createArticle(title,description,dueDate) {
        const articleElement = document.createElement('article');

        const h3Element = document.createElement('h3');
        h3Element.textContent = title;

        const pElementFirst = document.createElement('p');
        pElementFirst.textContent = `Description: ${description}`;

        const pElementSecond = document.createElement('p');
        pElementSecond.textContent = `Due Date: ${dueDate}`;

        const divElement = document.createElement('div');
        divElement.classList.add('flex');

        const buttonElementFirst = document.createElement('button');
        buttonElementFirst.classList.add('green');
        buttonElementFirst.textContent = 'Start';
        buttonElementFirst.addEventListener('click',inProgress)

        const buttonElementSecond = document.createElement('button');
        buttonElementSecond.classList.add('red');
        buttonElementSecond.textContent = 'Delete';
        buttonElementSecond.addEventListener('click',del)

        divElement.appendChild(buttonElementFirst);
        divElement.appendChild(buttonElementSecond);

        articleElement.appendChild(h3Element);
        articleElement.appendChild(pElementFirst);
        articleElement.appendChild(pElementSecond);
        articleElement.appendChild(divElement);

        return articleElement;
    }

    function inProgress(e){
        const inProgressSection = sections[2];
        const elementToMove = e.target.parentElement.parentElement;
        e.target.remove();

        const finishButton = document.createElement('button');
        finishButton.textContent = 'Finish';
        finishButton.classList.add('orange');
        finishButton.addEventListener('click',finish)

        elementToMove.querySelector('div').appendChild(finishButton);
        inProgressSection.lastElementChild.appendChild(elementToMove);
    }

    function finish(e) {
        const completeSection = sections[3];
        completeSection.lastElementChild.appendChild(e.target.parentElement.parentElement);
        e.target.parentElement.remove();
    }
    function del(e){
        e.target.parentElement.parentElement.remove();
    }
}