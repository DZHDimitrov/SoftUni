const {assert,expect} = require('chai');
const isOddOrEven = require('./evenOrOdd');

describe('isOddOrEven ',() => {
    it('should return even if string length is even',() => {
        expect(isOddOrEven('Daniel')).to.be.equal('even');
    });

    it('should return odd if string length is odd', () => {
        expect(isOddOrEven('Pesho')).to.be.equal('odd');
    });

    it('should return undefined if input type is not string', () => {
        expect(isOddOrEven(1)).to.be.undefined;
    });

    it('should return undefined if input is empty', () => {
        expect(isOddOrEven()).to.be.undefined;
    });

    //Overloading
    it('should return undefined if input type is not string', () => {
        expect(isOddOrEven([1,2,3])).to.be.undefined;
    });

    it('should return odd', () => {
        expect(isOddOrEven('asdf dsa qwert qq')).to.be.equal('odd');
    });

    it('should return even', () => {
        expect(isOddOrEven('asdf dsa qwert qq Peshoh')).to.be.equal('even');
    });
});