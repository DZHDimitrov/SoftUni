function addItem() {
    let elements = Array.from(document.querySelectorAll('article input'));
    elements.pop();

    let textElement = elements[0];
    let valueElement = elements[1];

    let optionElement = document.createElement('option');
    optionElement.innerHTML = textElement.value;
    optionElement.setAttribute('value',valueElement.value);
    textElement.value = '';
    valueElement.value = '';

    let dropdownElement = document.getElementById('menu');
    dropdownElement.appendChild(optionElement);
}