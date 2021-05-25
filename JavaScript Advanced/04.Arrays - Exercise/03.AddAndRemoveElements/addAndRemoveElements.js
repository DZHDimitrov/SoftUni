function solve(array){
    let numbers = [];

    array.forEach((x,y) => {
        if (x == 'add') {
            numbers.push(y+1)
        }
        else if (x == 'remove'){
            numbers.pop();
        }
    });
    numbers.length > 0 ? console.log(numbers.join('\n')) : console.log('Empty');
}
solve(['add', 
'add', 
'add', 
'add']
);