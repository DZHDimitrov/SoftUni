function solve(input) {
    let obj = {};
    let result = input.reduce((acc,el)=> {
        const line = el.split('=>');
        const [productName,currentPrice] = line;
        const price = Number(currentPrice);
        if (!acc[productName]) {
            acc[productName] = 0;
        }
        acc[productName] += price;
        if (acc[productName] >= 1000) {
            if (!obj[productName]) {
                obj[productName] = 0;
            }
            obj[productName] += parseInt(acc[productName] / 1000);
            acc[productName] = acc[productName] % 1000;
        }
        return acc;
    },{})

    for (const [key,value] of Object.entries(obj)) {
        console.log(`${key}=> ${value}`);
    }
}

// solve(['Orange => 2000',
// 'Peach => 1432',
// 'Banana => 450',
// 'Peach => 600',
// 'Strawberry => 549']
// );

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
)