function solve(array) {
    let input = array.toString().split(',');
    let matrix = [];
    input.forEach((x) => {
        let resultX = x.split(' ').map((y) => Number(y));
        matrix.push(resultX);
    });

    let mainDiagonal = 0;
    let secondaryDiagonal = 0;
    let diagonalIndexes = [];
    for (let i = 0; i < matrix.length; i++) {
        mainDiagonal += matrix[i][i];
        secondaryDiagonal += matrix[i][matrix.length-1-i];
        diagonalIndexes.push([i,i]);
        diagonalIndexes.push([i,matrix.length-1-i]);
    }
    
    if (mainDiagonal === secondaryDiagonal) {
        for (let i2 = 0; i2 < matrix.length; i2++) {
            for (let j2 = 0; j2 < matrix.length; j2++) {
                let contains = diagonalIndexes.some((x) => x.includes(i2) && x.includes(j2));
                if (!contains) {
                    matrix[i2][j2] = mainDiagonal;
                }
            }
            
        }
    }
    for (const row of matrix) {
        console.log(row.join(' '));
    }
}

solve(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
);