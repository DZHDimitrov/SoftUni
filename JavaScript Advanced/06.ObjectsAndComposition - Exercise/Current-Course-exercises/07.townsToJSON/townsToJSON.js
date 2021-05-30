function solve(array) {
    let objArray = [];
    let headings = array.shift();
    headings = headings.split(/\s*[|]\s*/g).filter(x=>x);
    array = array.map(x=> x.split(/\s*[|]\s*/g)).map(x=> x.filter(y=>y)).map(x=> x.join('@')).forEach(x=> {
        let line = x.split('@');
        let obj = {
            [headings[0]]: line[0],
            [headings[1]]: Number(Number(line[1]).toFixed(2)),
            [headings[2]]: Number(Number(line[2]).toFixed(2)),
        }
        objArray.push(obj);
    })

    console.log(JSON.stringify(objArray));
}

solve(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']
);