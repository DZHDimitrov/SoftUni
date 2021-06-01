function solve(array) {
    let numbers = [];
    let areRightOperands = true;
    for (let i = 0; i < array.length; i++) {
        if (typeof (array[i]) == 'number') {
            numbers.push(array[i]);
        } else {
            if (numbers.length < 2) {
                console.log("Error: not enough operands!");
                areRightOperands = false;
                break;
            }
            let number2 = numbers.pop();
            let number1 = numbers.pop();
            let currentResult = calculate(number1, number2, array[i]);
            numbers.push(currentResult);
        }
    }
    if (numbers.length > 1 && areRightOperands) {
        console.log("Error: too many operands!");
    } else if(areRightOperands){
        console.log(numbers[0]);
    }
    function calculate(operand1, operand2, operator) {
        switch (operator) {
            case '+':
                return operand1 + operand2;
            case '-':
                return operand1 - operand2;
            case '*':
                return operand1 * operand2;
            case '/':
                return operand1 / operand2;
        }
    }
}

solve([3,
    4,
    '+']
   );
solve([5,
    3,
    4,
    '*',
    '-']
   );
solve([7,
    33,
    8,
    '-']
);
solve([15,
    '/']
   );


