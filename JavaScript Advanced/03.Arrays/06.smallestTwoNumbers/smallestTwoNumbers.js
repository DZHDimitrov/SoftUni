function solve(numbers = []){
    let smallestNumbers = [];
    let first = Math.min(...numbers);
    numbers.splice(numbers.indexOf(first),1);
    let second = Math.min(...numbers);
    numbers.splice(numbers.indexOf(first),1);
    smallestNumbers.push(first);
    smallestNumbers.push(second);
    console.log(smallestNumbers.join(' '));
}

solve([30, 15, 50, 5]);