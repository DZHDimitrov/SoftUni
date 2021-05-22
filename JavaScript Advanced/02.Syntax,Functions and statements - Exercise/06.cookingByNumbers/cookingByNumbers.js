function solve(number, first, second, third, fourth, fifth) {
    let parsedNumber = Number(number);
    let realnumber = parsedNumber;
    realnumber = calculate(realnumber, first);
    realnumber = calculate(realnumber, second);
    realnumber = calculate(realnumber, third);
    realnumber = calculate(realnumber, fourth);
    realnumber = calculate(realnumber, fifth);
    function calculate(number, command) {
        if (command == 'chop') {
            number /= 2;
        }
        else if (command == 'dice') {
            number = Math.sqrt(number);
        }
        else if (command == 'spice') {
            number++;
        }
        else if (command == 'bake') {
            number *= 3;
        }
        else if (command == 'fillet') {
            number -= number * 0.20;
        }
        console.log(number);
        return number;
    }
};

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');