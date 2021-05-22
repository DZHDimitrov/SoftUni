function solve(fruit,weight,price){
    let weightInKg = weight / 1000;
    let overallPrice = (weightInKg * price).toFixed(2);
    console.log(`I need $${overallPrice} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`)
}
solve('orange',2500,1.80);