const {assert,expect} = require('chai');
const lookupChar = require('./charLookup');

describe('charLookup',() => {
    it('should return relevant char at index', () => {
        assert.equal(lookupChar('qwerty',0),'q');
    });
    it('should return relevant char at lastIndex', () => {
        assert.equal(lookupChar('qwerty',5),'y');
    });
    it('should return undefined if first parameter is not a string', () => {
        assert.isUndefined(lookupChar(10,1));
    });

    it('should return undefined if second parameter is not a number', () => {
        assert.isUndefined(lookupChar('qwerty','text'));
    });

    it('should return Incorrect index if index is bigger than text length', () => {
        assert.equal(lookupChar('someText',10),'Incorrect index');
    });
    it('should return Incorrect index if index is less than zero', () => {
        assert.equal(lookupChar('someText',-5),'Incorrect index');
    });
    it('should return Incorrect index if index is equal to string length', () => {
        assert.equal(lookupChar('someText',8),'Incorrect index');
    });
    it('should return undefined if index is floating number', () => {
        assert.isUndefined(lookupChar('someText',2.3));
    });
});