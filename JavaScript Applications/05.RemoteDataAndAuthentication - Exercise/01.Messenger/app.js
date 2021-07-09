function attachEvents() {
    let refreshBtn = document.getElementById('refresh');
    let submitBtn = document.getElementById('submit');

    refreshBtn.addEventListener('click', refresh);
    submitBtn.addEventListener('click', submit);
}

async function submit(e) {
    const authorElement = document.querySelector('#controls input[name="author"]');
    const contentElement = document.querySelector('#controls input[name="content"]');
    
    const author = authorElement.value;
    const content = contentElement.value;

    if (!author || !content) {
        return
    }

    const obj = {
        author,
        content,
    }

    authorElement.value = '';
    contentElement.value = '';

    const url = 'http://localhost:3030/jsonstore/messenger';

    //AJAX Request POST
    const response = await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(obj),
    });

    let textArea = document.querySelector('#main textarea');
    textArea.value += `\n${author}: ${content}`;
}

async function refresh(e) {
    let textArea = document.querySelector('#main textarea');
    const url = 'http://localhost:3030/jsonstore/messenger';

    //AJAX Request GET
    const response = await fetch(url);
    const data = await response.json();

    let result =
        Object.values(data)
            .map(el => `${el.author}: ${el.content}`)
            .join('\n');

    textArea.value = result;
} 

attachEvents();