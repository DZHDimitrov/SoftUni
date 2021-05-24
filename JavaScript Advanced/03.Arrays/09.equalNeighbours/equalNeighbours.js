function solve(matrix){
    let equals = 0;
    let rowIndex = 0;
    for (let row = 0; row < matrix.length-1; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            let test1 = matrix[row][col];
            let test2= matrix[row+1][col];
            if (test1 === test2 || matrix[row][col] == matrix[row][col+1]) {
                equals++;
            }
        } 
    }
    console.log(equals);
}

solve([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]

);