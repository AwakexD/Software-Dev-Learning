function Solve(input) {
    const CallorieBook = {}

    for (let i = 0; i < input.length; i+=2) {
        let product = input[i]
        let calories = input[i + 1]

        CallorieBook[product] = Number(calories)
    }

    console.log(CallorieBook);
}

Solve(['Yoghurt', '48', 'Rise', '138','Apple', '52'] );
