function solution(input) {
    let brands = new Map();

    input.forEach(line => {
        let [brand, model, quantity] = line.split(' | ');

        if (!brands.has(brand)) {
            let models = new Map();

            models.set(model, Number(quantity));
            brands.set(brand, models);
        } else {
            let currentBrandModels = brands.get(brand);

            if (!currentBrandModels.has(model)) {
                currentBrandModels.set(model, Number(quantity))
            } else {
                let modelQuantity = currentBrandModels.get(model);
                currentBrandModels.set(model, modelQuantity += Number(quantity));
            }
        }
    });

    let resultStr = "";
    for (const brand of brands) {
        resultStr += `${brand[0]}\n`;
        for (const model of brand[1]) {
            resultStr += `###${model[0]} -> ${model[1]}\n`;
        }
    } 

    return resultStr;
}

console.log(solution(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']));
