function solve(input) {
    let obj = {};

    input.forEach(x=> {
        let line = x.split(' <-> ');
        let [town,population] = line;
        if (!obj[town]) {
            obj[town] = Number(population);
        } else {
            obj[town] += Number(population);
        }
    });

    Object.keys(obj).forEach(key=> {
        console.log(`${key} : ${obj[key]}`);
    });
}

solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
);