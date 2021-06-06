function calculator() {
    let firstElement;
    let secondElement;
    let resultElement;

    return {
        init,
        add,
        subtract,
    }
    function init(selector1,selector2,resultSelector) {
        firstElement = document.querySelector(selector1);
        secondElement = document.querySelector(selector2);
        resultElement = document.querySelector(resultSelector);
    }
    function add() {
        resultElement.value = Number(firstElement.value) + Number(secondElement.value);
    }
    function subtract() {
        resultElement.value = Number(firstElement.value) - Number(secondElement.value);
    }
}

const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result');




