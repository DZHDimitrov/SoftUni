function solve(numbers) {
    let maxNumber = Number.MIN_VALUE;
    for (const row of numbers) {
        for (const element of row) {
            if (element > maxNumber) {
                maxNumber = element;
            }
        }
    }
    return maxNumber;
}

console.log(solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
   ));