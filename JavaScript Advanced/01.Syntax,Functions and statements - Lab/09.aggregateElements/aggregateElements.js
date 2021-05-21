function solve(params) {
    function sum(params) {
        let sumValue = 0;
        for (let i = 0; i < params.length; i++) {
            sumValue += params[i];
        }
        return sumValue;
    }
    function inverseSum(params) {
        let inverseValue = 0;
        for (let i = 0; i < params.length; i++) {
            inverseValue += 1 / params[i];
        }
        return inverseValue;
    }
    function concatenate(params) {
        let test = '';
        for (let i = 0; i < params.length; i++) {
            test += params[i];
        }
        return test;
    }
    let sumNumbers = sum(params);
    let inverseSumNumbers = inverseSum(params);
    let concatNumbers = concatenate(params);
    console.log(sumNumbers);
    console.log(inverseSumNumbers);
    console.log(concatNumbers);
}
solve([2,4,8,16]);