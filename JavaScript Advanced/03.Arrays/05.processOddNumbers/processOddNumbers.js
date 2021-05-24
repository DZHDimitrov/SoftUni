function solve (numbers){
    let newArray = numbers.filter((value,index) => index % 2 != 0).map((x) => x *2).reverse().join(' ');
    console.log(newArray);
}

solve([10, 15, 20, 25]);