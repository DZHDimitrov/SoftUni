function solve(argument = 5){
    let array = [argument];
    for(let i=0;i<argument;i++){
        for(let j=0;j<argument;j++){
            array[j]='*';
        }
        console.log(array.join(' '));
    }
}
solve(4);