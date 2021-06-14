function solve(input) {
    let result = input.reduce((acc, el) => {
        const [brand, model, currentPrice] = el.split(' | ');
        const price = Number(currentPrice);
        if (!acc[brand]) {
            acc[brand] = [];
        };
        const currentModel = { model, price };
        if (acc[brand].some(x => x.model == currentModel.model)) {
            acc[brand].find(x => x.model == currentModel.model).price += currentModel.price;
        } else {
            acc[brand].push(currentModel);
        }

        return acc;
    }, {});
    for (const [key, value] of Object.entries(result)) {
        console.log(key);
        for (const carModel of value) {
            console.log(`###${carModel.model} -> ${carModel.price}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
);