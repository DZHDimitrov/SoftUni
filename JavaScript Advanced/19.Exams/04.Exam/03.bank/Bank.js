class Bank {
    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer(customer){
        let [firstName,lastName,personalId] = Object.values(customer);

        if (this.allCustomers.some(x=> x.personalId == personalId)) {
            throw new Error(`${firstName} ${lastName} is already our customer!`)
        }

        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney(personalId,amount){
        let currentPerson = this.allCustomers.find(x=>x.personalId == personalId);
        if (!currentPerson) {
            throw new Error(`We have no customer with this ID!`)
        }
        if (!currentPerson['totalMoney']) {
            currentPerson['totalMoney'] = 0;
        }
        currentPerson['totalMoney'] += amount;
        if (!currentPerson['transactions']) {
            currentPerson['transactions'] = [];
        }

        let currentTransaction = {
            'numberOfTransaction': currentPerson['transactions'].length + 1,
            'names': `${currentPerson.firstName} ${currentPerson.lastName}`,
            'type': 'deposit',
            'amount':`${amount}`,
        };

        currentPerson['transactions'].push(currentTransaction);

        return `${currentPerson.totalMoney}$`;

    }
    withdrawMoney(personalId,amount){
        let currentPerson = this.allCustomers.find(x=>x.personalId == personalId);
        if (!currentPerson) {
            throw new Error(`We have no customer with this ID!`)
        }
        if (currentPerson.totalMoney < amount) {
            throw new Error(`${currentPerson.firstName} ${currentPerson.lastName} does not have enough money to withdraw that amount!`);
        }
        currentPerson['totalMoney'] -= amount;
        if (!currentPerson['transactions']) {
            currentPerson['transactions'] = [];
        }
        let currentTransaction = {
            'numberOfTransaction': currentPerson['transactions'].length + 1,
            'names': `${currentPerson.firstName} ${currentPerson.lastName}`,
            'type': 'withdraw',
            'amount':`${amount}`,
        };

        currentPerson['transactions'].push(currentTransaction);

        return `${currentPerson.totalMoney}$`;
    }
    customerInfo(personalId){
        let currentPerson = this.allCustomers.find(x=>x.personalId == personalId);
        if (!currentPerson) {
            throw new Error(`We have no customer with this ID!`)
        }
        let result = '';
        let arr = currentPerson['transactions'].reverse();
        result += `Bank name: ${this._bankName}\nCustomer name: ${currentPerson.firstName} ${currentPerson.lastName}\nCustomer ID: ${personalId}\nTotal Money: ${currentPerson.totalMoney}$\nTransactions:\n`;
        arr.forEach(x=> {
            let depositOrWithdraw = x.type == 'deposit' ? 'made deposit of' : 'withdrew';
            result += `${x.numberOfTransaction}. ${x.names} ${depositOrWithdraw} ${x.amount}$!\n`;
        });
        return result.trimEnd();
    }
}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({'firstName': 'Svetlin', 'lastName': 'Nakov', 'personalId': 6233267}));
console.log(bank.newCustomer({'firstName': 'Mihaela', 'lastName': 'Mileva', 'personalId': 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));

