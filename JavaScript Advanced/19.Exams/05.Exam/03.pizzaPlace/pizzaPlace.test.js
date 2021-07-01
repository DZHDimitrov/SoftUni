const {assert} = require('chai');
const pizzUni = require('./pizzaPlace');

describe("pizzUni", function() {
    describe("makeAnOrder", function() {
        it("Should throw an exception when a pizza is not ordered", function() {
            let obj = {
                'orderedDrink':'CokaCola',
            }
            assert.throws(() => {pizzUni.makeAnOrder(obj)});
        });

        it("Should order the pizza successfully when it is added in the object", function() {
            let obj = {
                'orderedPizza':'Margarita',
            }
            assert.equal(pizzUni.makeAnOrder(obj),`You just ordered Margarita`);
        });

        it('Should order successfully when pizza and drink are added', function() {
            let obj = {
                'orderedPizza':'Margarita',
                'orderedDrink':'Fanta',
            }
            assert.equal(pizzUni.makeAnOrder(obj), `You just ordered Margarita` + ` and Fanta.`)
        })
     });
     describe("getRemainingWork", function() {
        it("Should return correct message when all pizzas are ready", function() {
            let obj = {
                'pizzaName':'Margarita',
                'status':'ready',
            }
            let obj1 = {
                'pizzaName':'FourSeasons',
                'status':'ready',
            }
            let obj2 = {
                'pizzaName':'Kapritschoza',
                'status':'ready',
            }
            let arr = [];
            arr.push(obj);
            arr.push(obj1);
            arr.push(obj2);
            assert.equal(pizzUni.getRemainingWork(arr),'All orders are complete!');
        });

        it("Should return the preparing pizzas when there are some", function() {
            let obj = {
                'pizzaName':'Margarita',
                'status':'ready',
            }
            let obj1 = {
                'pizzaName':'FourSeasons',
                'status':'preparing',
            }
            let obj2 = {
                'pizzaName':'Kapritschoza',
                'status':'preparing',
            }

            let arr = [];
            arr.push(obj);
            arr.push(obj1);
            arr.push(obj2);

            assert.equal(pizzUni.getRemainingWork(arr),`The following pizzas are still preparing: FourSeasons, Kapritschoza.`);
        });
     });
     describe("orderType", function() {
        it("Should make a discount when type of order is Carry out", function() {
            
            assert.equal(pizzUni.orderType(10,'Carry Out'),9);
        });

        it("Should not make a discount and return the totalSum when type of order is Delivery", function() {
            assert.equal(pizzUni.orderType(10,'Delivery'),10);
        });
     });
});
