function solution() {
    const main = document.getElementById('main');
    main.addEventListener('click',showMore);
    getTitles();
}

function getTitles() {
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    fetch(url)
    .then(response => response.json())
    .then(data => {
        let result = Object.values(data).map(createDivElement).join('');
        main.innerHTML = result;
    })
    .catch(error => {
        alert('Error');
    })
}

function showMore(e) {
    const targetExtraElement = e.target.parentNode.nextElementSibling;

    if (e.target.className == 'button' && e.target.textContent == 'More') {
        const id = e.target.id;
        targetExtraElement.style.display = 'block';
        e.target.textContent = 'Less';
        const url = 'http://localhost:3030/jsonstore/advanced/articles/details/' + id;
        fetch(url)
            .then(response => response.json())
            .then(data => {
                targetExtraElement.firstElementChild.textContent = data.content;
            })
            .catch(error => {
                alert('Additional information is not found!');
            })
    } else if(e.target.className == 'button' && e.target.textContent == 'Less') {
        targetExtraElement.firstElementChild.textContent = '';
        e.target.textContent = 'More';
        targetExtraElement.style.display = 'none';
    }
}

function createDivElement(data) {
    
    const element = `<div class="accordion">
    <div class="head">
        <span>${data.title}</span>
        <button class="button" id="${data._id}">More</button>
    </div>
    <div class="extra">
        <p></p>
    </div>
</div>`;

    return element;
    
}
solution();