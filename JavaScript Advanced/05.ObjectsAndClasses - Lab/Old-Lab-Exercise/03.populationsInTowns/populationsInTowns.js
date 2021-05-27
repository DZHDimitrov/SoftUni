function solve(array) {
    let obj = {};
    array = array.map(x => x.split('<->').map(y => y.trim())).forEach(x => {
        if (obj[x[0]] == undefined) {

            obj[x[0]] = Number(x[1]);
        }
        else {
            obj[x[0]] = Number(obj[x[0]]) + Number(x[1]);
        }
    })
    Object.keys(obj).forEach(x => {
        console.log(`${x} : ${obj[x]}`);
    })


}

solve(['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']

);