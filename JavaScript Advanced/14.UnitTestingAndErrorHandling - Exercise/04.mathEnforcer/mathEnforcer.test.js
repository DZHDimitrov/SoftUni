const { assert, expect } = require('chai');
const mathEnforcer = require('./mathEnforcer');

describe('mathEnforcer', () => {
    describe('add', () => {
        it('method add should return undefined if does not recieve a number', () => {
            let num = mathEnforcer.addFive('5');

            assert.equal(num, undefined);
        });
        it('method add should return correct result', () => {
            let num = mathEnforcer.addFive(10);
    
            assert.equal(num, 15);
        });

        it('method add should work with floating numbers', () => {
            let num = mathEnforcer.addFive(12.5);
            assert.equal(num, 17.5);
        });

        it('method add should add approximately to 0.01 with floating numbers', ()=>{
            let num = mathEnforcer.addFive(12.5);
            expect(num).to.be.closeTo(17.5,0.01);
        });
        it('method add should work correctly with negative numbers', ()=> {
            let num = mathEnforcer.addFive(-5);
            assert.equal(num,0);
        })
    });

    describe('subtract', ()=> {
        it('method subtract should return undefined if does not recieve a number', () => {
            let num = mathEnforcer.subtractTen([1, 2, 3, 4, 5]);
            assert.isUndefined(num);
        });
        it('method subtract should return correct result', () => {
            let number = mathEnforcer.subtractTen(100);
    
            assert.equal(number, 90);
        });
        it('method subtract should work with floating numbers', () => {
            let number = mathEnforcer.subtractTen(100.5);
    
            assert.equal(number, 90.5);
        });
        it('method subtract should work with negative numbers', () => {
            let number = mathEnforcer.subtractTen(-10);

            assert.equal(number,-20);
        })
    });
    
    describe('sum', ()=> {
        it('method sum should return undefined if first parameter is not a number', () => {
            let num = mathEnforcer.sum('10', 5);
    
            assert.isUndefined(num);
        });
        it('method sum should return undefined if second parameter is not a number', () => {
            let num = mathEnforcer.sum(10, '5');
    
            assert.isUndefined(num);
        });
        it('method sum should return undefined if both parameters are not numbers', () => {
            let num = mathEnforcer.sum('10', '5');
    
            assert.isUndefined(num);
        });
    
        it('method sum should return correct result', () => {
            let num = mathEnforcer.sum(25, 25);
    
            assert.equal(num, 50);
        });
        it('method sum should work with floating numbers', () => {
            let num = mathEnforcer.sum(12.5, 10.5);
    
            assert.equal(num, 23);
        });
    });
});