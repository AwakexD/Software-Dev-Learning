function area() {
    return Math.abs(this.x * this.y);
}

function vol() {
    return Math.abs(this.x * this.y * this.z);
}

function solve(area, vol, input) {
    input = JSON.parse(input);
    let result = []

    for (const obj of input) {
        result.push({
            area : area.call(obj), 
            volume: vol.call(obj)
        });
    }

    console.log(result);

}

function solve2(area, vol, input) {
    cordinates = JSON.parse(input);

    let result = cordinates.map(x => {
        return {
            area : area.call(x),
            volume : vol.call(x),
        }
    })

    return result;
}


solve(area, vol, `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`);

solve(area, vol, `[
    {"x":"10","y":"-22","z":"10"},
    {"x":"47","y":"7","z":"-5"},
    {"x":"55","y":"8","z":"0"},
    {"x":"100","y":"100","z":"100"},
    {"x":"55","y":"80","z":"250"}
    ]`
    );