function solve(numbers){
    let newArray = [];
    for (let index = 0; index < numbers.length; index++) {
        let currentNumber = numbers[index];
        if (currentNumber < 0) {
            newArray.unshift(currentNumber);
        }
        else{
            newArray.push(currentNumber);
        }
    }
    newArray.forEach((x) => console.log(x));
}

solve([3, -2, 0, -1]);