function solve(array) {
    let obj = {};
    array.forEach((element,index) => {
        if (index % 2 == 0) {
            obj[element] = Number(array[index+1]);
        }
    });
    console.log(obj);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);