function solve(array){
    let biggestNumbers = [];
    let biggestNumber = Number.MIN_SAFE_INTEGER;
    for (const number of array) {
        if (number >= biggestNumber) {
            biggestNumbers.push(number);
            biggestNumber = number;
        }
    }

    return biggestNumbers;
}

solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    
);