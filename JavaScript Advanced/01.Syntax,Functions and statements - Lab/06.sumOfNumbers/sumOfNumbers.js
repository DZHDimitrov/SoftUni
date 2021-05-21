function solve(number1,number2){
    let num1 = Number(number1);
    let num2 = Number(number2);
    let sum = 0;

    for(let i=num1;i<=num2;i++){
        sum += i;
    }
    return sum;
}
console.log(solve('1','2'))