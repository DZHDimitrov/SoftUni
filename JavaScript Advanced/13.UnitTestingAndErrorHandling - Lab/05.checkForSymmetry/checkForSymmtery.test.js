const isSymmetric = require('./checkForSymmetry');
const {assert} = require('chai');

describe('isSymetric', () => {
    it('should return false if input is incorrect', () =>
    assert.isFalse(isSymmetric('1')));

    it('should return true if the array is symmetric', () => {
        assert.isTrue(isSymmetric([1,1]));
    });
    it('should return false if the array is not symmteric', () => {
        assert.isFalse(isSymmetric([1,2]));
    });

    it('should return false if the array contains different types', () => {
        assert.isFalse(isSymmetric(['1',2]));
    });

    it('should return false if the array contains different types but equal', () => {
        assert.isFalse(isSymmetric(['1',1]));
    })
})