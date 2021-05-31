function sumTable() {
    let elements = Array.from(document.querySelectorAll('tr'));
    elements.shift();
    let lastElement = elements.pop();
    let sum = 0;
    elements.forEach(x=> {
        let number = Number(x.lastElementChild.innerHTML);
        sum+= number;
    });

    lastElement.lastElementChild.innerHTML = sum;
}