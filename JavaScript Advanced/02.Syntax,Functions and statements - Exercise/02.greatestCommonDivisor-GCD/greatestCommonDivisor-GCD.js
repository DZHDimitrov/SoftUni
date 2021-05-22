function solve(number1,number2){
    let biggerNumber = Math.max(number1,number2);
    let commonDivisor = 0;
    for(let i = 1; i<=biggerNumber;i++){
        if(number1 % i == 0 && number2 % i == 0){
            commonDivisor = i;
        }
    }
    console.log(commonDivisor);
}
solve(2154,458);