const {assert} = require('chai');
const testNumbers = require('./testNumbers');

describe("testNumbers", function() {
    describe("sumNumber", function() {
        it("should return undefined when first argument is not a number", function() {
            assert.isUndefined(testNumbers.sumNumbers('1',2));
        });
        it("should return undefined when second argument is not a number", function() {
            assert.isUndefined(testNumbers.sumNumbers(1,'2'));
        });
        it("should return undefined when both arguments are not numbers", function() {
            assert.isUndefined(testNumbers.sumNumbers('1','2'));
        });
        it("should return the sum of numbers fixed to second decimal point when arguments are valid", function() {
            assert.equal(testNumbers.sumNumbers(1,2),3.00);
            assert.equal(testNumbers.sumNumbers(5,6),11.00);
            assert.equal(testNumbers.sumNumbers(5.531,5),10.53);
            assert.equal(testNumbers.sumNumbers(5.5555,5),10.56);
            assert.equal(testNumbers.sumNumbers(5.5555,5),10.56);
            assert.equal(testNumbers.sumNumbers(5,-5),0);
        });
     });
     describe("numberChecker", function() {
        it("should throw an exception when the input cannot be parsed to a number", function() {
            assert.throws(() => {testNumbers.numberChecker('asd')},'The input is not a number!');
            assert.throws(() => {testNumbers.numberChecker('a312sd')},'The input is not a number!');
        });
        it("should return correct message if the number is even", function() {
            assert.equal(testNumbers.numberChecker('2'),'The number is even!');
            assert.equal(testNumbers.numberChecker(2),'The number is even!');
            assert.equal(testNumbers.numberChecker(10),'The number is even!');
            assert.equal(testNumbers.numberChecker('16'),'The number is even!');
        });
        it("should return correct message if the number is odd", function() {
            assert.equal(testNumbers.numberChecker('3'),'The number is odd!');
            assert.equal(testNumbers.numberChecker(5),'The number is odd!');
            assert.equal(testNumbers.numberChecker(15),'The number is odd!');
            assert.equal(testNumbers.numberChecker('17'),'The number is odd!');
        });
     });
     describe("averageSumArray", function() {
        it("should return the average sum from an input array", function() {
            assert.equal(testNumbers.averageSumArray([1,2,3,4,5]),3);
            assert.equal(testNumbers.averageSumArray([1,2,3,4]),2.5);
        });
     });
});
