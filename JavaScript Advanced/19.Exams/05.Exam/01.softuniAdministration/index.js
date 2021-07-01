function solve() {
    const addBtn = document.querySelector('.container .actions form button');
    const modules = {};

    addBtn.addEventListener('click',(e) => {
        e.preventDefault();

        const lectureName = document.querySelector('[name="lecture-name"]');
        const date = document.querySelector('[name="lecture-date"]');
        const module = document.querySelector('[name="lecture-module"]');

        if (!lectureName.value || !date.value || module.value == 'Select module') {
            return;
        }

        if (!modules[module.value]) {
            modules[module.value] = [];
        }

        let currentLecture = {'name':lectureName.value,'date':formatDate(date.value)};

        modules[module.value].push(currentLecture);

        lectureName.value = '';
        date.value = '';
        module.value = 'Select module';

        createTrainings(modules);
    })

    function createTrainings(modules){
        let modulesElement = document.querySelector('.modules');
        modulesElement.innerHTML = '';

        for (const moduleName in modules) {
            let moduleElement = createModule(moduleName);
            let lectureList = document.createElement('ul');

            let lectures = modules[moduleName];
            lectures
                .sort((a,b) => a.date.localeCompare(b.date))
                .forEach(({name,date}) => {
                    let lectureElement = createLecture(name,date);
                    lectureList.appendChild(lectureElement);

                    let buttonDel = lectureElement.querySelector('button');
                    buttonDel.addEventListener('click',(e) => {
                        modules[moduleName] = modules[moduleName].filter(x=> !(x.name==name && x.date == date));

                        if (modules[moduleName].length == 0) {
                            delete modules[moduleName];
                            e.currentTarget.parentElement.parentElement.parentElement.remove();
                        }else {
                            e.currentTarget.parentElement.remove();
                        }
                    })
                })
            moduleElement.appendChild(lectureList);
            modulesElement.appendChild(moduleElement);
        }
    }
    function createModule(moduleName){
        let divElement = document.createElement('div');
        divElement.classList.add('module');

        let h3Element = document.createElement('h3');
        h3Element.textContent = `${moduleName.toUpperCase()}-MODULE`;

        divElement.appendChild(h3Element);

        return divElement;
    }

    function createLecture(name,date){
        let liElement = document.createElement('li');
        liElement.classList.add('flex');

        let h4Element = document.createElement('h4');
        h4Element.textContent = `${name} - ${date}`;

        let btnElement = document.createElement('button');
        btnElement.classList.add('red');
        btnElement.textContent = 'Del';

        liElement.appendChild(h4Element);
        liElement.appendChild(btnElement);

        return liElement;
    }
    function formatDate(date) {
        let line = date.split('T');
        let currentDate = line[0].split('-').join('/');
        let time = line[1];

        return `${currentDate} - ${time}`;
    }
};