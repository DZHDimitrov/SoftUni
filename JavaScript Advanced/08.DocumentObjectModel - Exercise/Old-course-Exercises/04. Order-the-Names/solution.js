function solve() {
    let button = document.querySelector('button');
        button.addEventListener('click',register);

    function register() {
        let elements = Array.from(document.querySelectorAll('li'));
        let inputElement = document.querySelector('#exercise article input');
        let inputText = inputElement.value;
        let numberInAlphabet = inputText.toLowerCase().charCodeAt(0) - 96;
        inputElement.value = '';
        let resultArray = [];
        for (let i = 0; i < elements.length; i++) {
            if (i+1 == numberInAlphabet) {
                if (elements[i].innerHTML !== '') {
                    resultArray.push(elements[i].innerHTML);
                }
                resultArray.push(inputText);
                elements[i].innerHTML = resultArray.join(', ')
            }
        }
    }
}