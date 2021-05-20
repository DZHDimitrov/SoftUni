function solve(text1,text2,text3){
    let sum = text1.length + text2.length + text3.length;
    console.log(sum);
    let average = Math.floor(sum / 3);
    console.log(average);
}

solve('chocolate', 'ice cream', 'cake');