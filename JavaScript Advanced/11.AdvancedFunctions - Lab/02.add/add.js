function solve(number) {
    let myNumber = number;
    return (test) => number + test
}

let add7 = solve(7);
console.log(add7(2));
console.log(add7(3));


