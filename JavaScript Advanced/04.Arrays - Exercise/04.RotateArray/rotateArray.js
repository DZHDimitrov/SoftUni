function solve(array,rotations){
    while (rotations > 0) {
        let element = array.pop();
        array.unshift(element);
        rotations--; 
    }
    console.log(array.join(' '));
}

solve(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
);