class ChristmasDinner {
    constructor(budget) {
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    get budget() {
        return this._budget;
    }

    set budget(value) {
        if (value < 0 || typeof value != 'number') {
            throw new Error(`The budget cannot be a negative number`);
        }
        this._budget = value;
    }

    shopping(productArr) {
        let [productName, productPrice] = productArr;
        productPrice = Number(productPrice);

        if (productPrice > this.budget) {
            throw new Error(`Not enough money to buy this product`);
        }
        this.products.push(productName);
        this.budget -= productPrice;
        return `You have successfully bought ${productName}!`;
    }

    recipes(recipe) {
        let recipeName = recipe['recipeName'];
        let productsList = recipe['productsList'];
        if (!this._checkIfProductsAreInside(productsList)) {
            throw new Error("We do not have this product")
        }
        this.dishes.push({ recipeName, productsList });
        return `${recipeName} has been successfully cooked!`;
    }

    _checkIfProductsAreInside(productsList) {
        for (const product of productsList) {
            if (!this.products.includes(product)) {
                return false;
            }
        }
        return true;
    }

    inviteGuests(name,dish){
        if (!this.dishes.some(x=>x.recipeName == dish)) {
            throw new Error('We do not have this dish');
        }
        if (this.guests[name]) {
            throw new Error(`This guest has already been invited`);
        }
        this.guests[name] = dish;
        return `You have successfully invited ${name}!`;
    }
    showAttendance(){
        let result = '';
        Object.keys(this.guests).forEach(x=> {
            let currentDish = this.guests[x];
            let productsOfDish = this.dishes.find(x=> x.recipeName == currentDish).productsList;
            result += `${x} will eat ${currentDish}, which consists of ${productsOfDish.join(', ')}\n`;
        })
        return result.trimEnd();
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());

