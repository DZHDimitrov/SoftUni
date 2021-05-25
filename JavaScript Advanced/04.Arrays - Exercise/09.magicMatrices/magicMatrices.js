function solve(matrix){
    for (let i = 0; i < matrix.length-1; i++) {
        let rowOne = matrix[i].reduce((a,b) => a + b, 0);
        let rowNext = matrix[i+1].reduce((a,b) => a + b, 0);
        let colOne = 0;
        let colNext = 0;

        for (let j = 0; j < matrix.length; j++) {
            colOne += matrix[i][j];
            colNext += matrix[i+1][j];           
        }
        
        if (rowOne != rowNext || colOne != colNext) {
            return false;
        }
    }
    return true;
}

console.log(solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
   
   ));