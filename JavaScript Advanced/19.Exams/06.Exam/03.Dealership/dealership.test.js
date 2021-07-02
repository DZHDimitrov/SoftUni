const {assert} = require('chai');
const dealership = require('./dealership');

describe("dealership", function() {
    describe("newCarCost", function() {
        it("Should make a discount when the old car is being returned", function() {
            let carModel = 'Audi A4 B8';

            assert.equal(dealership.newCarCost(carModel,20000),5000);
        });
        it('Should not make a discount when the old car is not being returned',function() {
            let carModel = 'Mazerati B4 B3';

            assert.equal(dealership.newCarCost(carModel,20000),20000);
        })
     });
     describe("carEquipment", function() {
        it("Should set add only the selected extras", function() {
            let myArr = ['mirrors','air conditioner','lights','back-seats','belts'];
            let selected = [0,1,4];

            assert.deepEqual(dealership.carEquipment(myArr,selected),['mirrors','air conditioner','belts'])
        });
     });
     describe("euroCategory", function() {
        it("Should return proper message when euro category is low", function() {

            assert.equal(dealership.euroCategory(3),'Your euro category is low, so there is no discount from the final price!');
        });
        it("Should make a discount when category is higher", function() {
            
            assert.equal(dealership.euroCategory(5),`We have added 5% discount to the final price: 14250.`);
            assert.equal(dealership.euroCategory(4),`We have added 5% discount to the final price: 14250.`);
        });
     });
});
