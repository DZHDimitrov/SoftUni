function colorize() {
    let elements = Array.from(document.getElementsByTagName('tr'));
    elements.shift();
    for (let i = 0; i < elements.length; i++) {
        if (i % 2 === 0) {
            let element = elements[i];
            element.style.backgroundColor = 'teal';
            element.style.backgroundColor = 'teal';
        }
    }
}