function editElement(htmlElement,match,replacer) {
    htmlElement.innerHTML = htmlElement.innerHTML.replace(match,replacer);
}