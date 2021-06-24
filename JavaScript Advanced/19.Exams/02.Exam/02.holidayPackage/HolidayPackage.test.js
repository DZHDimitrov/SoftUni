const {assert} = require('Chai');
const HolidayPackage = require('./HolidayPackage');

describe('HolidayPackage',() =>{
    describe('constructor', () => {
        it('should have season when it is instantiated', () => {
            let myTest = new HolidayPackage('Bulgaria','Summer');

            assert.equal(myTest.season,'Summer');
        })
        it('should have country when it is instantiated', () => {
            let myTest = new HolidayPackage('Bulgaria','Summer');

            assert.equal(myTest.destination,'Bulgaria');
        });
        it('should have property empty array as vacationers when it is instantiated', () => {
            let myTest = new HolidayPackage('Bulgaria','Summer');

            assert.deepEqual(myTest.vacationers,[]);
        });
        it('should have property for insurance set to false', () => {
            let myTest = new HolidayPackage('Bulgaria','Summer');

            assert.equal(myTest.insuranceIncluded,false);
        })
    });
    describe('showVacationers',() =>{
        it('should return all vacationers if there are any', () =>{
            let myTest = new HolidayPackage('Bulgaria','Summer');
            myTest.vacationers = ['Pesho','Maryia','Susan'];

            let myVacationers = ['Pesho','Maryia','Susan'];
            assert.equal(myTest.showVacationers(),`Vacationers:\n${myVacationers.join('\n')}`)

            myTest.vacationers = ['Pesho'];
            myVacationers = ['Pesho'];

            assert.equal(myTest.showVacationers(),`Vacationers:\n${myVacationers.join('\n')}`);
        })
        it('should return proper message if there are no vacationers', () =>{
            let myTest = new HolidayPackage('Bulgaria','Summer');
            myTest.vacationers = [];

            assert.deepEqual(myTest.showVacationers(),`No vacationers are added yet`)
        })
    });
    describe('addVacationer',() => {
        it('should throw an error if the argument is invalid',() =>{
            let myTest = new HolidayPackage('Bulgaria','Summer');

            assert.throws(() => {myTest.addVacationer(1),'Vacationer name must be a non-empty string'})
            assert.throws(() => {myTest.addVacationer(''),'Vacationer name must be a non-empty string'})
            assert.throws(() => {myTest.addVacationer(1.5),'Vacationer name must be a non-empty string'})
            assert.throws(() => {myTest.addVacationer(' '),'Vacationer name must be a non-empty string'})
        })
        it('should throw an error if the argument is two part string',() =>{
            let myTest = new HolidayPackage('Bulgaria','Summer');

            assert.throws(() => {myTest.addVacationer('Daniel'),'Name must consist of first name and last name'})
            assert.throws(() => {myTest.addVacationer('DanielDimitrov'),'Name must consist of first name and last name'})
            assert.throws(() => {myTest.addVacationer('Daniel Jivkov Dimitrov'),'Name must consist of first name and last name'})
        })
        it('should add vacationer to vacationers collection',() => {
            let myTest = new HolidayPackage('Bulgaria','Summer');

            myTest.addVacationer('Daniel Dimitrov');

            assert.deepEqual(myTest.vacationers,['Daniel Dimitrov']);
        })
    });
    describe('insuranceIncludedGetter',() => {
        it('should return the value of insuranceIncluded property',() => {
            let myTest = new HolidayPackage('Bulgaria','Summer');

            assert.equal(myTest.insuranceIncluded,false);

            myTest.insuranceIncluded = true;

            assert.equal(myTest.insuranceIncluded,true);
        })
    })
    describe('insuranceIncludedSetter',() => {
        it('should throw an error if the argument type is not boolean', () => {
            let myTest = new HolidayPackage('Bulgaria','Summer');

            assert.throws(() => {myTest.insuranceIncluded = 5,"Insurance status must be a boolean"});
            assert.throws(() => {myTest.insuranceIncluded = 'true',"Insurance status must be a boolean"});
            assert.throws(() => {myTest.insuranceIncluded = 'false',"Insurance status must be a boolean"});
        })
        it('should set insuranceIncluded property', () =>{
            let myTest = new HolidayPackage('Bulgaria','Summer');
            myTest.insuranceIncluded = true;

            assert.equal(myTest.insuranceIncluded,true);

            myTest.insuranceIncluded = false;
            assert.equal(myTest.insuranceIncluded,false);
        })
    });
    describe('generateHolidayPackage',() => {
        it('should throw an error if there are no vacationers',() =>{
            let myTest = new HolidayPackage('Bulgaria','Summer');
            assert.throws(()=> myTest.generateHolidayPackage(),"There must be at least 1 vacationer added");
        });
        it('should calculate prize properly if the season is not Summer or Winter and Insurance is not included',() => {
            let myTest = new HolidayPackage('Bulgaria','Autumn');
            myTest.addVacationer('Daniel Dimitrov');
            myTest.addVacationer('Borislava Dimova');
            myTest.insuranceIncluded = false;

            const totalPrice = myTest.vacationers.length * 400;

            let text = "Holiday Package Generated\n" +
            "Destination: " + myTest.destination + "\n" +
            myTest.showVacationers() + "\n" +
            "Price: " + totalPrice;

            assert.equal(myTest.generateHolidayPackage(),text);
        })
        it('should calculate prize properly if the season is not Summer or Winter and Insurance is included',() => {
            let myTest = new HolidayPackage('Bulgaria','Autumn');
            myTest.addVacationer('Daniel Dimitrov');
            myTest.addVacationer('Borislava Dimova');
            myTest.insuranceIncluded = true;

            let totalPrice = myTest.vacationers.length * 400;
            totalPrice += 100;
            let text = "Holiday Package Generated\n" +
            "Destination: " + myTest.destination + "\n" +
            myTest.showVacationers() + "\n" +
            "Price: " + totalPrice;

            assert.equal(myTest.generateHolidayPackage(),text);
        })
        it('should calculate prize properly if the season is Summer or Winter and Insurance is not included',() => {
            let myTest = new HolidayPackage('Bulgaria','Summer');
            myTest.addVacationer('Daniel Dimitrov');
            myTest.addVacationer('Borislava Dimova');
            myTest.insuranceIncluded = false;

            let totalPrice = myTest.vacationers.length * 400;
            totalPrice += 200;
            let text = "Holiday Package Generated\n" +
            "Destination: " + myTest.destination + "\n" +
            myTest.showVacationers() + "\n" +
            "Price: " + totalPrice;

            assert.equal(myTest.generateHolidayPackage(),text);
        })
        it('should calculate prize properly if the season is Summer or Winter and Insurance is included',() => {
            let myTest = new HolidayPackage('Bulgaria','Summer');
            myTest.addVacationer('Daniel Dimitrov');
            myTest.addVacationer('Borislava Dimova');
            myTest.insuranceIncluded = true;

            let totalPrice = myTest.vacationers.length * 400;
            totalPrice += 200;
            totalPrice += 100;
            let text = "Holiday Package Generated\n" +
            "Destination: " + myTest.destination + "\n" +
            myTest.showVacationers() + "\n" +
            "Price: " + totalPrice;

            assert.equal(myTest.generateHolidayPackage(),text);
        })
    })
})