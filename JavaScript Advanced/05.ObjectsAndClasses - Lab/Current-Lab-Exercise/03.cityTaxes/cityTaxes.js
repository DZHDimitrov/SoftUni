function createCity() {
    return {
        name: 'Tortuga',
        population: 7000,
        treasury: 15000,
        taxRate: 10,

        collectTaxes() {
            this.treasury += this.population * this.taxRate;
        },

        applyGrowth(percentage) {
            this.population += Math.floor(this.population * percentage / 100);
        },

        applyRecession(percentage) {
            this.treasury -= Math.floor(this.treasury * parseInt(percentage) / 100);
        }
    }
}

const city = createCity();
console.log(city);
