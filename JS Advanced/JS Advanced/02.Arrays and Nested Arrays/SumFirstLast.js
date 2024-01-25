function Solve(array) {
    let firstElement = array.shift()
    let lastElement = array.pop()

    console.log(Number(firstElement) + Number(lastElement));
}

Solve(['20', '40', '60'])