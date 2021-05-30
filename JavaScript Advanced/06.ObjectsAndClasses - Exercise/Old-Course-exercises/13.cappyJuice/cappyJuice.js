function solve(input) {
    let obj = {};
    let sortedObj = {};

    input.forEach(x => {
        let [juiceName,juiceQuantity] = x.split(' => ');

        if (!obj[juiceName]) {
            obj[juiceName] = Number(juiceQuantity);
        }

        else {
            obj[juiceName] += Number(juiceQuantity);
        }
        
        if (obj[juiceName] >= 1000 && !sortedObj[juiceName]) {
            sortedObj[juiceName] = obj[juiceName];
        }
        else if (obj[juiceName] >= 1000 && Object.keys(sortedObj).includes(juiceName)) {
            sortedObj[juiceName] += Number(juiceQuantity);
        }

        
    })
    Object.keys(sortedObj).forEach(x=> {
        console.log(`${x} => ${(sortedObj[x] / 1000) >> 0}`)
    })
}

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
);