
// Function Expression
let countDown = function(number){
    for(let i = number; i > 0; i--){
        console.log(i)
    }
};
countDown(5)

// Arrow Function
let countUp = (max) => {
    for(let i = 0; i < max; i++){
        console.log(i)
    }
};
countUp(3)

//Return Value
function sum(a, b){
    return a + b
};

let arrowSum = (a, b) => a + b;

// Methods
let name = "Pesho"
console.log(name.toUpperCase());

// JavaScript standart libraries : 
//  Math, Number, Date, RegExp, JSON

function solve(first, second, third){
    console.log("Total length: " + (first.length + second.length + third.length))
    let avereage = Math.floor(first.length + second.length + third.length / 3)
    console.log("Average length: " + avereage);
};

solve('pasta', '5', '22.3')
