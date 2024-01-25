function cityTaxes(name, population, treasury){
    return  {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes: () => {
            this.treasury += Math.round(this.population * this.taxRate);
        },
        applyGrowth: (percentage) => {
            this.population += Math.round(this.population * (percentage / 100))
        },
        applyRecession: (percentage) => {
            this.treasury *= (Math.round(percentage / 100));
        },
    }
}

const city =
 cityTaxes('Tortuga',
 7000,
 15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);

