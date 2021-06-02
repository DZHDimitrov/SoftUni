function toggle() {
    let button = document.querySelector('.button');
    let buttonText = button.innerHTML;
    console.log(buttonText == 'More');
    let paragraphElement = document.querySelector('#extra');

    if (buttonText == 'More') {
        button.innerHTML = 'Less';
        paragraphElement.style.display = 'block';
    }
    else if (buttonText == 'Less') {
        button.innerHTML = 'More';
        paragraphElement.style.display = 'none';
    }
}