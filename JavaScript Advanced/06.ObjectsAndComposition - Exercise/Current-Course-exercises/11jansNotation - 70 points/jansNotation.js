function solve(array) {
    let index = 0;
    let operators = ['+', '-', '*', '/'];
    let numbers = [];
    let operands = [];
    while (true) {
        if (index > array.length - 1) {
            break;
        }
        if (!operators.includes(array[index])) {
            numbers.push(array[index])
        } else {
            operands.push(array[index]);
        }

        index++;
    }
    while (true) {
        if (numbers.length >= 2 && operands.length > 0) {
        
        let numberOne = numbers[numbers.length-2];
        let numberTwo = numbers[numbers.length-1];
        numbers.pop();
        numbers.pop();
        numbers.push(Math.ceil(calculate(operands.shift(),numberOne,numberTwo)));

        if (numbers.length == 1 && operands.length == 0) {
            console.log(numbers[0]);
            break;
        }
        }
        else if (numbers.length > 1 && operands.length == 0) {
            console.log('Error: too many operands!');
            break;
        }
        else if (numbers.length == 1 && operands.length >= 1) {
            console.log('Error: not enough operands!');
            break;
        }


    }

    function calculate(operand, a, b) {
        switch (operand) {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                return a / b;
        }
    }
}

solve([-1,
    1,
    '+',
    101,
     '*',
    18,
'+',
3,
'/',
]   
   );

   