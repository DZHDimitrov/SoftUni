const { assert } = require('chai');
const createCalculator = require('./addAndSubtract');

describe('createCalculator', () => {
    let calc;
    beforeEach(() => calc = createCalculator());

    it('should return a function', () => {
        assert.equal(typeof calc, 'object');
    });

    it('add function should add numbers', () => {
        calc.add(5);
        calc.add(10);
        assert.equal(calc.get(), 15);
    });

    it('value should be value zero initially', () => {
        assert.equal(calc.get(),0);
    })

    it('subtract function should subtract numbers', () => {
        calc.subtract(10);
        calc.subtract(10);

        assert.equal(calc.get(), -20);
    });

    it('add function should work with fractions', () => {
        calc.add(3.14);
        calc.add(4.14);

        assert.equal(calc.get(), 7.279999999999999)
    });

    it('subtract function should work with fractions', () => {
        calc.add(-3.14);
        calc.add(-4.14);

        assert.equal(calc.get(), -7.279999999999999)
    });

    it('add function should return NaN if invalid input', () => {
        calc.add('someNumber');

        assert.isNaN(calc.get());
    });

    it('subtract function should return NaN if invalid input', () => {
        calc.subtract('someNumber');

        assert.isNaN(calc.get());
    });

    it('add function should return NaN if input is empty', () => {
        calc.add();

        assert.isNaN(calc.get());
    });
    it('subtract function should return NaN if input is empty', () => {
        calc.add();

        assert.isNaN(calc.get());
    });

    it('add function should work with numbers as strings', () => {
        calc.add('125');

        assert.equal(calc.get(), 125);
    });

    it('subtract function should work with numbers as strings', () => {
        calc.subtract('10');

        assert.equal(calc.get(), -10);
    });

    it('check both functions with string inputs', () => {
        calc.add('someNumber');
        calc.subtract('anotherNumber');

        assert.isNaN(calc.get());
    })
});