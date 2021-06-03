function addItem() {
    let ulElement = document.getElementById('items');
    let newElement = document.createElement('li');
    let inputValue = document.getElementById('newItemText');

    newElement.innerHTML = inputValue.value;
    newElement.addEventListener('click',remove)
    
    let linkElement = document.createElement('a');
    linkElement.setAttribute('href','#');
    linkElement.textContent = '[Delete]';
    linkElement.addEventListener('click',remove)
    newElement.appendChild(linkElement);
    ulElement.appendChild(newElement);
    
    function remove(ev) {
        ev.currentTarget.parentNode.remove();
    }
}