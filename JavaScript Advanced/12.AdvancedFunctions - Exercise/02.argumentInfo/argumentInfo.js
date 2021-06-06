function solve(...input) {
    let sorted = [];
    let result = Object.entries(input.reduce((acc,el)=> { 
        console.log(`${typeof(el)}: ${el}`);
        let currentType = typeof(el);
        if (!acc[currentType]) {
            acc[currentType] = 0;
        }
        acc[currentType] += 1;
        return acc;
    },{}));
    for (const [key,value] of result) {
        sorted.push([key,value]);
    }
    sorted.sort((a,b) => b[1] - a[1]).forEach(x=> console.log(`${x[0]} = ${x[1]}`));
}

solve('cat', 42, function () { console.log('Hello world!'); },function () { console.log('Hello world!'); });