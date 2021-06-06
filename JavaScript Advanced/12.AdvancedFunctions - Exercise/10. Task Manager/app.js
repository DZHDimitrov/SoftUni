function solve() {
    let open = document.getElementsByTagName('section')[1];
    let inProgress = document.getElementsByTagName('section')[2];
    let complete = document.getElementsByTagName('section')[3];

    let task = document.getElementById('task');
    let description = document.getElementById('description');
    let date = document.getElementById('date');

    document.getElementById('add').addEventListener('click', add);

    function add(ev) {
        ev.preventDefault();
        if (!task.value || !description.value || !date.value) {
            return;
        }
        let article = createEl('article');
        let h3 = createEl('h3', task.value);
        let firstP = createEl('p', `Description: ${description.value}`);
        let secondP = createEl('p', `Due Date: ${date.value}`);
        let div = createEl('div', null, 'flex');
        let greenBtn = createEl('button', 'Start', 'green');
        let redBtn = createEl('button', 'Delete', 'red');
        div.appendChild(greenBtn);
        div.appendChild(redBtn);
        article.appendChild(h3);
        article.appendChild(firstP);
        article.appendChild(secondP);
        article.appendChild(div);
        open.children[1].appendChild(article);
        task.value = '';
        description.value = '';
        date.value = ''
        greenBtn.addEventListener('click', inProgressFunc)

        redBtn.addEventListener('click', remove)

        function remove() {
            article.remove();
        }
        function inProgressFunc() {
            let orangeBtn = createEl('button', 'Finish', 'orange');
            greenBtn.remove();
            div.appendChild(orangeBtn);
            orangeBtn.addEventListener('click', () => {
                div.remove();
                complete.children[1].appendChild(article);
            })
            inProgress.children[1].appendChild(article);
        }
    }


    function createEl(type, content, className) {
        let element = document.createElement(type);

        if (content) {
            element.textContent = content;
        }
        if (className) {
            element.setAttribute('class', className);
        }

        return element;
    }

}