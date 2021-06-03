function addItem() {
    let element = document.getElementById('items');
    let input = document.getElementById('newItemText');
    let newElement = document.createElement('li');
    newElement.innerHTML = input.value;
    element.appendChild(newElement);
}