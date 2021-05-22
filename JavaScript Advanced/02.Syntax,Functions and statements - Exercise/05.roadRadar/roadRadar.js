function solve(speed, area) {
    let motorwaySpeed = 130;
    let interstateSpeed = 90;
    let citySpeed = 50;
    let residentialSpeed = 20;
    let result = 0;
    if (area == 'motorway') {
        motorwaySpeed -= speed;
        let absValue = Math.abs(motorwaySpeed);
        if (motorwaySpeed > 0) {
            console.log(`Driving ${speed} km/h in a ${motorwaySpeed + speed} zone`)
        }
        else{
            let status = getStatus(Math.abs(motorwaySpeed))
            console.log(`The speed is ${absValue} km/h faster than the allowed speed of ${motorwaySpeed+speed} - ${status}`)
        }
    }
    else if (area == 'interstate') {
        interstateSpeed -= speed;
        let absValue = Math.abs(interstateSpeed);
        if (interstateSpeed > 0) {
            console.log(`Driving ${speed} km/h in a ${interstateSpeed + speed} zone`)
        }
        else{
            let status = getStatus(Math.abs(interstateSpeed))
            console.log(`The speed is ${absValue} km/h faster than the allowed speed of ${interstateSpeed+speed} - ${status}`)
        }
    }
    else if (area == 'city') {
        citySpeed -= speed;
        let absValue = Math.abs(citySpeed);
        if (citySpeed > 0) {
            console.log(`Driving ${speed} km/h in a ${citySpeed + speed} zone`)
        }
        else{
            let status = getStatus(Math.abs(citySpeed))
            console.log(`The speed is ${absValue} km/h faster than the allowed speed of ${citySpeed+speed} - ${status}`)
        }
    }
    else if (area == 'residential') {
        residentialSpeed -= speed;
        let absValue = Math.abs(residentialSpeed)
        if (residentialSpeed > 0) {
            console.log(`Driving ${speed} km/h in a ${residentialSpeed + speed} zone`)
        }
        else{
            let status = getStatus(Math.abs(residentialSpeed))
            console.log(`The speed is ${absValue} km/h faster than the allowed speed of ${residentialSpeed+speed} - ${status}`)
        }
    }
    function getStatus(speed) {
        if (speed >= 1 && speed <= 20) {
            return 'speeding'
        }
        else if (speed >= 21 && speed <= 40) {
            return 'excessive speeding'
        }
        else {
            return 'reckless driving';
        }
    }
}
solve(200,'motorway');