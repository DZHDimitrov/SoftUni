function solve() {
    let availableMicros = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0,
    }
    return manager;

    function manager(command) {
        let input = command.split(' ');
        let word = input[1];
        let prop = '';
        if (word) {
            prop = word[word.length - 1] == 's' && word.includes('carbo') ? word.substring(0, word.length - 1) : word;
        }

        if (input[0] == 'restock') {
            availableMicros[prop] += Number(input[2]);
            return 'Success';
        } else if (input[0] == 'prepare') {
            let arr = [];
            for (let i = 0; i < Number(input[2]); i++) {
                arr.push(createRecipe(prop, availableMicros));
            };

            if (!checkIfAllAvailable(arr, availableMicros).isValid) {
                return `Error: not enough ${checkIfAllAvailable(arr, availableMicros).micro} in stock`
            }
            arr.forEach(x => {
                Object.keys(x).forEach(y => {
                    availableMicros[y] -= x[y];
                })
            })
            return 'Success';
        } else if (input[0] = 'report') {
            let result = [];
            for (const [key, value] of Object.entries(availableMicros)) {
                result.push([key, value]);
            }
            return result.map(x => x.join('=')).join(' ');
        }
    }
    function checkIfAllAvailable(array, products) {
        let myProducts = Object.assign({}, products);
        for (const obj of array) {
            for (const key in obj) {
                if (myProducts[key] < obj[key] || !myProducts[key]) {
                    return {
                        micro: key,
                        isValid: false,
                    };
                } 
                myProducts[key] -= obj[key];
            }
        }
        return { micro: null, isValid: true };
    }

    function createRecipe(name, products) {
        if (name == 'apple') {
            return { carbohydrate: 1, flavour: 2 };
        } else if (name == 'lemonade') {
            return { carbohydrate: 10, flavour: 20 };
        } else if (name == 'burger') {
            return { carbohydrate: 5, fat: 7, flavour: 3 };
        } else if (name == 'eggs') {
            return { protein: 5, fat: 1, flavour: 1 };
        } else if (name == 'turkey') {
            return { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 };
        }
    }
}

let manager = solve();

console.log (manager ("restock flavour 50")); // Success 
console.log (manager ("prepare lemonade 4")); // Error: not enough carbohydrate in stock 
console.log (manager ("restock carbohydrates 10")); // Error: not enough carbohydrate in stock 
console.log (manager ("restock flavour 10")); // Error: not enough carbohydrate in stock 
console.log (manager ("prepare apple 1")); // Error: not enough carbohydrate in stock 
console.log (manager ("restock fat 10")); // Error: not enough carbohydrate in stock 
console.log (manager ("prepare burger 1")); // Error: not enough carbohydrate in stock 
console.log (manager ("report")); // Error: not enough carbohydrate in stock 


// console.log(manager("prepare turkey 1")); // Success 
// console.log(manager("restock protein 10")); // Error: not enough carbohydrate in stock 
// console.log(manager("prepare turkey 1")); // Error: not enough carbohydrate in stock 
// console.log(manager("restock carbohydrate 10")); // Error: not enough carbohydrate in stock 
// console.log(manager("prepare turkey 1")); // Error: not enough carbohydrate in stock 
// console.log(manager("restock fat 10")); // Error: not enough carbohydrate in stock 
// console.log(manager("prepare turkey 1")); // Error: not enough carbohydrate in stock 
// console.log(manager("restock flavour 10")); // Error: not enough carbohydrate in stock 
// console.log(manager("prepare turkey 1")); // Error: not enough carbohydrate in stock 
// console.log(manager("report")); // Error: not enough carbohydrate in stock 

