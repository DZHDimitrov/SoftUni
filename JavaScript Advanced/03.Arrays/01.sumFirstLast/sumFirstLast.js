function solve(numbers){
    let firstElement = Number(numbers[0]);
    let lastElement = Number(numbers[numbers.length-1]);
    let sum = firstElement + lastElement;
    console.log(sum);
}

solve(['5', '10']);