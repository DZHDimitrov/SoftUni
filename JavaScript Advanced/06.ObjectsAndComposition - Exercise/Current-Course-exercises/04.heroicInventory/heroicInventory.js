function solve(array) { 
    let resultArray = [];

    array.forEach(x=> {
        let [name,level,others] = x.split(' / ');
        let items = others ? others.split(', ') : [];
        let obj = {
            name: name,
            level: Number(level),
            items: items,
        }
        resultArray.push(obj);
    });
    console.log(JSON.stringify(resultArray));
    let arr = [1,2,3,4,5,6,7,8,9,10];

    console.log(arr.reduce((a,b) => a + b,0));
}

solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
);