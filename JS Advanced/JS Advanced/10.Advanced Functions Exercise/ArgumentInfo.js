function solution(...arguments) {
    const tally = {};

    for (const item of arguments) {
        const type = typeof(item);
        
        if (!tally.hasOwnProperty(type)) {
            tally[type] = 0;
        }

        tally[type]++;

        console.log(`${type} : ${item}`);
    }

    const result = Object.entries(tally)
        .map(([key, value]) => `${key} : ${value}`)
        .join('\n');

    return result;
}

console.log(solution('cat', 42, function () { console.log('Hello world!'); }));