let { Repository } = require("./solution.js");
let { assert } = require('chai');
describe("Repository", function () {
    let props = {
        name: "string",
        age: "number",
        birthday: "object"
    };

    describe("Constructor", function () {
        it("Should return the count of stored entities", function () {
            let myInstance = new Repository(props);
            assert.deepEqual(myInstance.props, props);
        });
    });
    describe("GetterCount", function () {
        it("Should return the count of stored entities", function () {
            let myInstance = new Repository(props);
            assert.equal(myInstance.count, 0);
            myInstance.add({ 'name': 'Pesho', 'age': 15, 'birthday': new Date(1998, 0, 7) });
            myInstance.add({ 'name': 'Jelio', 'age': 25, 'birthday': new Date(1998, 0, 7) });
            myInstance.add({ 'name': 'Nikolay', 'age': 3, 'birthday': new Date(1998, 0, 7) });

            assert.equal(myInstance.count, 3);
        });
    });
    describe("add", function () {
        it("Should throw an error when property does not exist", function () {
            let myInstance = new Repository(props);

            let entity = {
                'name': 'Pesho',
                'age': 15,
            }
            assert.throws(() => { myInstance.add(entity) }, `Property birthday is missing from the entity!`)
        });
        it("Should throw an error when property is incorrect type", function () {
            let myInstance = new Repository(props);

            let entity = {
                'name': 'Pesho',
                'age': '15',
                'birthday': new Date(1998, 0, 7)
            }
            assert.throws(() => { myInstance.add(entity) }, TypeError, `Property age is not of correct type!`)

            entity = {
                'name': 'Pesho',
                'age': 15,
                'birthday': '1998/07/05'
            }
            assert.throws(() => { myInstance.add(entity) }, TypeError, `Property birthday is not of correct type!`)
        });
        it("Should add entity to the collection when valid and returns id", function () {
            let myInstance = new Repository(props);

            let entity = {
                'name': 'Pesho',
                'age': 15,
                'birthday': new Date(1998, 0, 7)
            }
            assert.equal(myInstance.add(entity), 0);
            assert.equal(myInstance.count, 1);
            assert.deepEqual(myInstance.data, new Map().set(0, { name: 'Pesho', age: 15, birthday: new Date(1998, 0, 7) }));
        });
    });
    describe("GetId", function () {
        it("Should throw an error when id does not exist", function () {
            let myInstance = new Repository(props);
            myInstance.add({ 'name': 'Pesho', 'age': 15, 'birthday': new Date(1998, 0, 7) });
            myInstance.add({ 'name': 'Jivko', 'age': 15, 'birthday': new Date(1998, 0, 7) });

            assert.throws(() => { myInstance.getId(2) }, `Entity with id: 2 does not exist!`)
        });
        it("Should return the entity when id exists", function () {
            let myInstance = new Repository(props);
            myInstance.add({ 'name': 'Pesho', 'age': 15, 'birthday': new Date(1998, 0, 7) });
            myInstance.add({ 'name': 'Jivko', 'age': 25, 'birthday': new Date(1998, 0, 7) });
            myInstance.add({ 'name': 'Maryia', 'age': 22, 'birthday': new Date(1998, 0, 7) });

            assert.deepEqual(myInstance.getId(0), { 'name': 'Pesho', 'age': 15, 'birthday': new Date(1998, 0, 7) })
            assert.deepEqual(myInstance.getId(1), { 'name': 'Jivko', 'age': 25, 'birthday': new Date(1998, 0, 7) })
            assert.deepEqual(myInstance.getId(2), { 'name': 'Maryia', 'age': 22, 'birthday': new Date(1998, 0, 7) })
        });
    });
    describe("update", function () {
        it("Should throw an error when id does not exist", function () {
            let myInstance = new Repository(props);
            myInstance.add({ 'name': 'Pesho', 'age': 15, 'birthday': new Date(1998, 0, 7) });
            myInstance.add({ 'name': 'Jivko', 'age': 15, 'birthday': new Date(1998, 0, 7) });

            assert.throws(() => { myInstance.update(2) }, `Entity with id: 2 does not exist!`)
        });
        it("Should throw an error when property does not exist", function () {
            let myInstance = new Repository(props);
            myInstance.add({ 'name': 'Maryia', 'age': 15, 'birthday': new Date(1998 / 05 / 05) })
            let entity = {
                'name': 'Pesho',
                'age': 15,
            }
            assert.throws(() => { myInstance.update(0, entity) }, `Property birthday is missing from the entity!`)
        });
        it("Should throw an error when property is incorrect type", function () {
            let myInstance = new Repository(props);
            myInstance.add({ 'name': 'Maryia', 'age': 15, 'birthday': new Date(1998 / 05 / 05) })
            let entity = {
                'name': 'Pesho',
                'age': '15',
                'birthday': new Date(1998, 0, 7)
            }
            assert.throws(() => { myInstance.update(0, entity) }, TypeError, `Property age is not of correct type!`)

            entity = {
                'name': 'Pesho',
                'age': 15,
                'birthday': '1998/07/05'
            }
            assert.throws(() => { myInstance.update(0, entity) }, TypeError, `Property birthday is not of correct type!`)
        });
        it("Should update the entity with given id when the new entity is valid", function () {
            let myInstance = new Repository(props);
            myInstance.data.set(1, { 'name': 'Pesho', 'age': 15, 'birthday': new Date(1998, 0, 7) });

            let entity = {
                'name': 'Pesho',
                'age': 15,
                'birthday': new Date(1998 / 05 / 05),
            }
            let mySecondEntity = {
                'name': 'Pesho',
                'age': 20,
                'birthday': new Date(1998 / 05 / 05),
            }
            myInstance.add(entity);

            myInstance.update(1, mySecondEntity)
            let test = myInstance.getId(1);
            assert.equal(test.age, 20)
            assert.deepEqual(test, mySecondEntity);
        });
    });
    describe("del", function () {
        it("Should throw an error when id does not exist", function () {
            let myInstance = new Repository(props);
            myInstance.data.set(1, { 'name': 'Pesho', 'age': 15, 'birthday': new Date(1998, 0, 7) });

            assert.throws(() => { myInstance.del(2) }, `Entity with id: 2 does not exist!`)
        });
        it("Should remove entity when it exists", function () {
            let myInstance = new Repository(props);
            myInstance.add({ 'name': 'Pesho', 'age': 15, 'birthday': new Date(1998, 0, 7) });
            myInstance.add({ 'name': 'Toshko', 'age': 22, 'birthday': new Date(1996, 0, 7) });

            assert.equal(myInstance.count, 2);

            let obj = myInstance.getId(0);
            assert.equal(obj.name, 'Pesho');

            myInstance.del(0)
            assert.equal(myInstance.count, 1);
            assert.throws(() => { myInstance.getId(0) });

            let mySecondRep = new Repository(props);
            myInstance.del(1);
            assert.equal(mySecondRep.count, 0);
        });
    });

});
