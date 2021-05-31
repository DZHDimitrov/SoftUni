function calc() {
    let firstElement = document.getElementById('num1');
    let secondElement = document.getElementById('num2');
    let sumElement = document.getElementById('sum');
    sumElement.value = Number(firstElement.value) + Number(secondElement.value);
}
