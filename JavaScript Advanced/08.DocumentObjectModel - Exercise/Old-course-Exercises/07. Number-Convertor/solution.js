function solve() {
    let selectionParent = document.querySelector('#selectMenuTo');
    let child = selectionParent.firstElementChild;
    child.innerHTML = 'Binary'
    child.setAttribute('value','binary');

    let newOption = selectionParent.firstElementChild.cloneNode();
    newOption.innerHTML = 'Hexadecimal';
    newOption.setAttribute('value','hexadecimal');

    selectionParent.appendChild(newOption);

    let buttonElement = document.querySelector('#container button');
    buttonElement.addEventListener('click',convert);

    function convert(x) {
        let inputNumber = Number(document.querySelector('#input').value);
        let option = document.querySelector('#selectMenuTo').value;
        let resultElement = document.querySelector('#result');
        
        let resultArray = [];
        if (option == 'binary') {
            while (inputNumber != 0) {
                if (inputNumber % 2 == 0) {
                    resultArray.push(0);
                }
                else if (inputNumber % 2 != 0) {
                    resultArray.push(1);
                }
                inputNumber = parseInt(inputNumber / 2);
            }
        }
        else if (option == 'hexadecimal'){
            while (inputNumber != 0) {
                if (inputNumber % 16 == 0) {
                    resultArray.push(0);
                }
                else if (inputNumber % 16 != 0) {
                    let reminder = inputNumber % 16;
                    let outputReminder = reminder === 10 ? 'A' : reminder === 11 ? 'B' : reminder === 12 ? 'C' : reminder === 13 ? 'D' : reminder === 14 ? 'E' : reminder === 15 ? 'F' : reminder;
                    resultArray.push(outputReminder);
                }
                inputNumber = parseInt(inputNumber / 16);
            }
        }
        resultArray.reverse();
        resultElement.value = resultArray.join('');
    }
}