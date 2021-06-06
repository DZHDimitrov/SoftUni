function solve() {
    let numbers = [1];

    return () => {
        if (numbers.length == 1 || numbers.length == 2) {
            numbers.push(1);
        } else {
            numbers.push(numbers[numbers.length-1] + numbers[numbers.length-2]);
        }
        return numbers[numbers.length-1];
    }
}

let fib = solve();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
