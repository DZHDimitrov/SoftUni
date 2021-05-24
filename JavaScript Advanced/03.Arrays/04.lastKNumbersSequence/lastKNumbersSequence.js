function solve(n, k) {
    let newArray = [1];
    for (let index = 1; index < n; index++) {
        if (index < k) {
            let sum = 0;
            let array = newArray.slice(0, index);
            for (let j = 0; j < array.length; j++) {
                sum+=array[j];
            }
            newArray.push(sum);
        }
        else {
            let sum = 0;
            let array = newArray.slice(index - k, index);
            for (let j = 0; j < array.length; j++) {
                sum+= array[j];               
            }
            // sum = array.reduce((a, x) => a + x, 0);
            newArray.push(sum);
        }
    }
    return `[${newArray.join(', ')}]`;
}

console.log(solve(6,3));