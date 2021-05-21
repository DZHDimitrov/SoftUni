function solve(argument){
    if (typeof argument == 'number') {
        let radius = Math.PI * (Math.pow(argument,2))
        console.log(radius.toFixed(2))
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof(argument)}`)
    }
}

solve('name');