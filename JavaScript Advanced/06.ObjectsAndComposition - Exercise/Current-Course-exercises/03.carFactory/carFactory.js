let car = {
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
};


function solve(car) {
    let carPower = car.power <= 90 ? 90 : car.power > 90 && car.power <= 120 ? 120 : car.power;
    let volume = carPower >= 90 && carPower < 120 ? 1800 : carPower >= 120 && carPower < 200 ? 2400 : carPower >= 200 ? 3500 : 0;
    let wheel = car.wheelsize % 2 == 0 ? car.wheelsize-1 : car.wheelsize;
    let allTires = [wheel,wheel,wheel,wheel];
    let newModel = {
        model: car.model,
        engine: { power: carPower,volume:volume},
        carriage: { type: car.carriage, color: car.color},
        wheels: allTires,
    }
    return newModel;
}

console.log(solve(car));