function solve(array) {
    array
    .sort((current, next) => compare(current,next))
    .forEach(x=> console.log(x));

    function compare(current,next){
        if (current.length > next.length) {
            return 1;
        }
        else if (current.length === next.length) {
            return current.localeCompare(next);
        }
        else {
            return -1;
        }
    }
}



solve(['test', 
'Deny', 
'omen', 
'Default']
);
