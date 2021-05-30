function solve(array){

    // let resultArray = array.map(x=> {
    //     let line = x.replace(' :',':');
    //     return line;
    // })
    // let test = resultArray.sort((a,b) => {
    //     return a.localeCompare(b);
    // })
    let previousLetter = '';
    array.sort((a,b) => a.localeCompare(b)).map(x=> x.replace(' :',':')).forEach((x,i)=> {
        let currentLetter = x[0];
        if (currentLetter != previousLetter) {
            console.log(currentLetter.toUpperCase());
            console.log(`  ${x}`);
            previousLetter = currentLetter;
        }
        else {
            console.log(`  ${x}`);
        }

    })
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);