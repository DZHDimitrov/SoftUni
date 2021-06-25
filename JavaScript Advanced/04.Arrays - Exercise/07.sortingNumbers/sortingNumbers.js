function solve(arr) {
    arr.sort((a,b) => a-b);
    let resultArr = [];
    let start = 0;
    let end = arr.length-1;
    while (arr.length > 0) {
        resultArr.push(arr.shift())
        if (arr.length !== 0) {
            resultArr.push(arr.pop());
        }   
    }
    return resultArr;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));