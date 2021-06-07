const {expect,assert} = require('chai');
const sum =  require('./sumOfNumbers');

describe('sum function should work as expected', () => {
    it('should sum single number',() => {
        assert.equal(sum([1]),1);
    });

    it('should return sum of multiple numbers', () => {
        assert.equal(sum([5,10,15]),30);
    });
});