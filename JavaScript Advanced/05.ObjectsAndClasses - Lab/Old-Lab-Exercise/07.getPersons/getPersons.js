class Person {
    constructor (firstName,lastName,age,email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.email = email;
    }

    toString() {
        `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`
    }
}
function solve() {
    let arr = [];
    arr.push(
        new Person('Anna','Simpson',22,'anna@yahoo.com'),
        new Person('SoftUni'),
        new Person('Stephan','Johnson',25),
        new Person('Gabriel','Peterson',24,'g.p@gmail.com'),
        );
        for (const iterator of arr) {
            console.log(Object.values(iterator));
        }
        return arr;
}

console.log(solve());