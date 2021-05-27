function solve(input) {
    let result = [];
    
    let splitInput = input.map(x=> x.split('|').filter(x => x != '').map(x=> x.trim()));

    let head = splitInput.shift();

    splitInput.forEach((x)=> {
        let latitude = x[1];
        let longitute = x[2];
        let obj = {
            [head[0]]: x[0],
            [head[1]]: Number(Number(latitude).toFixed(2)),
            [head[2]]: Number(Number(longitute).toFixed(2)),
        }
        result.push(obj);
    });

    result = JSON.stringify(result);
    console.log(result);
}

solve(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']
);