function addItem() {
    let parent = document.getElementById('menu');
    let newItemText = document.getElementById('newItemText').value;
    let newItemValue = document.getElementById('newItemValue').value;

    let newElement = document.createElement('option');
    newElement.textContent = newItemText;
    newElement.value = newItemValue;
    document.getElementById('newItemText').value = '';
    document.getElementById('newItemValue').value = '';
    parent.appendChild(newElement);
}