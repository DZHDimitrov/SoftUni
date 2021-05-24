function solve(numbers){
    let evenNumbers = [];
    for (const key in numbers) {
        if (key % 2 == 0) {
            evenNumbers.push(numbers[key])
        }
    }
    console.log(evenNumbers.join(' '));
}

solve(['20', '30', '40']);