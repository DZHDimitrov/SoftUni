function solve(array,step){
    let resultArray = [];
    let counter = 1;
    resultArray.push(array.shift())
    for (let index = 0; index < array.length; index++) {
        if (counter == step) {
            resultArray.push(array[index]);
            counter = 0;
        }
        counter++;
    }
    return resultArray;
}

solve(['5', 
'20', 
'31', 
'4', 
'20',
'2'], 
);