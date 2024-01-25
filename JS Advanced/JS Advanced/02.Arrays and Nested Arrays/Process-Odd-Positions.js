function Solve(array) {
    let resultArr = []
    for (let i = 0; i < array.length; i++) {
        if(i % 2 != 0){
            resultArr.push(array[i] * 2)
        }
        
    } 

    console.log(...resultArr.reverse());
}

Solve([10, 15, 20, 25])
Solve([3, 0, 10, 4, 7, 3])