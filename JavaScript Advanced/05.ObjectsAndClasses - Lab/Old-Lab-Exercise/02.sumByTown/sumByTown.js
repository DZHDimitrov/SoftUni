function solve(array) {
    let obj = {};

    array.forEach((town,index) => {
        if (index % 2 == 0) {
            if (obj[town] == undefined) {
                obj[town] = Number(array[index +1]);
            }
            else {
                obj[town] += Number(array[index + 1]);
            }
        }
        
    })

    let result = JSON.stringify(obj);
    console.log(result);
}

solve(['Sofia','20','Varna','3','Sofia','5','Varna','4']);