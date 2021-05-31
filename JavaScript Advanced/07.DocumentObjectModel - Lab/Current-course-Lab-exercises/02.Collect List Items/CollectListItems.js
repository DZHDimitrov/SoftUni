function extractText() {
    let listItems = Array.from(document.querySelectorAll('li'));
    let output = document.getElementById('result');
    listItems.forEach(x=> {
        let value = x.innerHTML;
        output.innerHTML += `${value}\n`
    });
}