function solve(matrix){
    let numbersToSum1 = 0;
    let numbersToSum2 = 0;
    console.log(matrix.length)
    for (let index = 0; index < matrix.length; index++) {
        numbersToSum1 += (matrix[index][index]);
        numbersToSum2 += (matrix[matrix.length-1-index][index]);
    }
    let sums = [numbersToSum1,numbersToSum2];
    console.log(sums.join(' '))
}

solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
   );