function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}

console.log(parseInt('123asd') + 5);
let create = createCalculator();
create.add(1);
create.add(2);
create.add(2);
console.log(create.get());
module.exports = createCalculator;
