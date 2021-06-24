class Vacationer{
    constructor(fullName,creditCard) {
        if (!creditCard) {
            this.creditCard = {'cardNumber':1111,'expirationDate':'','securityNumber':111};
        } else {
            const [cardNumber,expirationDate,securityNumber] = creditCard;

            if (creditCard.length < 3) {
                throw new Error('Missing credit card information');
            }
            if (typeof cardNumber !== 'number' || typeof securityNumber !== 'number') {
                throw new Error('Invalid credit card details');
            }
            this.creditCard = {cardNumber,expirationDate,securityNumber};
        }
        
        this.fullName = fullName;
        this.wishList = [];
        this.idNumber = this.generateIDNumber();
    }

    get fullName() {
        return this._fullName;
    }
    set fullName(array) {
        let [firstName,middleName,lastName] = array;
        let name = array.join(' ');
        if (array.length !== 3) {
            throw new Error('Name must include first name, middle name and last name');
        }
        if (!/^[A-Z][a-z]+\s[A-Z][a-z]+\s[A-Z][a-z]+$/g.test(name)) {
            throw new Error('Invalid full name')
        }
        this._fullName = {firstName,middleName,lastName};
    }

    generateIDNumber() {
        let number = 231 * this.fullName.firstName.charCodeAt(0) + 139 * this.fullName.middleName.length;
        const vowels = ['a','e','o','i','u'];
        if (vowels.includes(this.fullName.lastName[this.fullName.lastName.length-1])) {
            number += '8';
        } else{
            number += '7';
        }
        return number;
    }
    addCreditCardInfo(array) {
        const [cardNumber,expirationDate,securityNumber] = array;
        if (array.length < 3) {
            throw new Error('Missing credit card information');
        }
        if (typeof cardNumber !== 'number' || typeof securityNumber !== 'number') {
            throw new Error('Invalid credit card details');
        }
        this.creditCard = {cardNumber,expirationDate,securityNumber};
    }
    addDestinationToWishList(destination){
        if (this.wishList.includes(destination)) {
            throw new Error('Destination already exists in wishlist');
        }
        this.wishList.push(destination);
        this.wishList.sort((a,b) => a.length - b.length);
    }
    getVacationerInfo() {
        const wishListText = this.wishList.length == 0 ? 'empty' : this.wishList.join(', ');

        const firstName = this.fullName.firstName
        const middleName = this.fullName.middleName
        const lastName = this.fullName.lastName

        const cardNumber = this.creditCard.cardNumber;
        const expirationDate = this.creditCard.expirationDate;
        const securityNumber = this.creditCard.securityNumber;

        return `Name: ${firstName} ${middleName} ${lastName}\nID Number: ${this.idNumber}\nWishlist:\n${wishListText}\nCredit Card:\nCard Number: ${cardNumber}\nExpiration Date: ${expirationDate}\nSecurity Number: ${securityNumber}`;
    }
}

// Initialize vacationers with 2 and 3 parameters
let vacationer1 = new Vacationer(["Vania", "Ivanova", "Zhivkova"]);
let vacationer2 = new Vacationer(["Tania", "Ivanova", "Zhivkova"], 
[123456789, "10/01/2018", 777]);

// Should throw an error (Invalid full name)
try {
    let vacationer3 = new Vacationer(["Vania", "Ivanova", "ZhiVkova"]);
} catch (err) {
    console.log("Error: " + err.message);
}

// Should throw an error (Missing credit card information)
try {
    let vacationer3 = new Vacationer(["Zdravko", "Georgiev", "Petrov"]);
    vacationer3.addCreditCardInfo([123456789, "20/10/2018"]);
} catch (err) {
    console.log("Error: " + err.message);
}

vacationer1.addDestinationToWishList('Spain');
vacationer1.addDestinationToWishList('Germany');
vacationer1.addDestinationToWishList('Bali');

// Return information about the vacationers
console.log(vacationer1.getVacationerInfo());
console.log(vacationer2.getVacationerInfo());
