class Person {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    get fullName() {
        return `${this.firstName} ${this.lastName}`
    }

    set fullName(value) {
       let line = value.split(' ');
       this.firstName = line[0];
       this.lastName = line[1];

    }
}

