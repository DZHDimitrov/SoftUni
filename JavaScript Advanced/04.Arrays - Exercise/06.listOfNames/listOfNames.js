function solve(array) {
    array.sort((a, b) => {
        return a.localeCompare(b)
    });
    let counter = 1;
    console.log(array.map((x) => {
        let newX = counter + '.' + (x);
        counter++;
        return newX;
    }).join('\n'));
}

solve(["John", "Bob", "Christina", "Ema"]);