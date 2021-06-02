function solve() {
    let elements = Array.from(document.querySelector('.keys').children);
    console.log(elements.length);
    elements.forEach(x => {
        let buttonValue = x.value;
        x.addEventListener('click', calculate);
    });

    let button = document.querySelector('.clear');
    button.addEventListener('click', clear)

    function calculate(element) {
        let operators = ['+', '-', 'x', '/'];
        let expressionElement = document.querySelector('#expressionOutput');
        let resultElement = document.querySelector('#resultOutput');
        let currentElement = element.currentTarget;

        if (currentElement.innerHTML == '=') {
            let operator = findOperator(expressionElement.innerHTML);
            let array = expressionElement.innerHTML.split(/[+-/x ]/g).filter(x => x);
            console.log(array.length);
            if (array.length == 1) {
                resultElement.innerHTML += NaN;
            }
            else {
                let result = findResult(Number(array[0]), operator, Number(array[1]));
                resultElement.innerHTML += result;
            }
        }
        else if (operators.includes(currentElement.innerHTML)) {
            expressionElement.innerHTML += ' ' + currentElement.innerHTML + ' ';
        }
        else {

            expressionElement.innerHTML += currentElement.innerHTML;
        }
    }
    function clear() {
        let expressionElement = document.querySelector('#expressionOutput');
        let resultElement = document.querySelector('#resultOutput');
        resultElement.innerHTML = '';
        expressionElement.innerHTML = '';
    }
    function findResult(a, operator, b) {
        switch (operator) {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case 'x':
                return a * b;
            case '/':
                return a / b;
        }
    }

    function findOperator(text) {
        let operators = ['+', '-', 'x', '/'];

        for (let i = 0; i < text.length; i++) {
            if (operators.includes(text[i])) {
                return text[i];
            }
        }
    }

}