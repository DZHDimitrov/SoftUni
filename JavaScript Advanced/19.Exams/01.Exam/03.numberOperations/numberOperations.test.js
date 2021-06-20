const {assert} = require('chai');
const numberOperations = require('./03. Number Operations_Resources');


describe("numberOperations", () => {
    describe("powNumber", () => {
        it("should return power of the given number", () => {
            const number = 5;
            assert.equal(numberOperations.powNumber(5),25);
            assert.equal(numberOperations.powNumber(2),4);
        });
     });
     describe("numberChecker", () => {
        it("should parse the input", () => {
            let a = '123';
            assert.equal(numberOperations.numberChecker(a),'The number is greater or equal to 100!');
            a = '100';
            assert.equal(numberOperations.numberChecker(a),'The number is greater or equal to 100!');
            a = '50';
            assert.equal(numberOperations.numberChecker(a),'The number is lower than 100!');
            a = '0';
            assert.equal(numberOperations.numberChecker(a),'The number is lower than 100!');
        });
        it("should validate the input", () => {
            let a = '1a2b3';
            assert.throws(() => numberOperations.numberChecker(a),'The input is not a number!');
        });
     });
     describe("sumsArray", () => {
        it("should sum two arrays", () => {
           let myFirstArr = [1,2,3];
           let mySecondArr = [1,2];
           let result = [2,4,3];
           assert.deepEqual(numberOperations.sumArrays(myFirstArr,mySecondArr),result);
           myFirstArr = [5,10,15,20,25];
           mySecondArr = [3,5,7,9,11,13,15,17,19,21,23,25];

           result = [8,15,22,29,36,13,15,17,19,21,23,25]
           assert.deepEqual(numberOperations.sumArrays(myFirstArr,mySecondArr),result);

           
        });
        it("should validate the input", () => {
        });
     });
     
});
