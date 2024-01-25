let names = ['Pesho', 'Gosho', 'Maria'];

names[-1] = "secret";
//----Output Array----
names.forEach(element => console.log(element));

names[names.length] = "asfds"

console.log(...names);

console.log(names.join('\n'));

console.log(names);

//-----Array Destructuring Assigment Syntaxis------

let [name1, name2, name3, ...others] = names;

console.log(others);

//---------Mutator Methods------------

let nums = [10, 20, 30, 40, 50, 60, 70];

console.log(nums.length);
console.log(nums.pop());

nums.push(100);

// Queue methods 
console.log(nums.shift());
let newLength = nums.unshift(10)

console.log(nums);

// Splice Method
let cars = ['Honda', 'Audi', 'Mercedes']

cars.splice(1, 0, 'BMW', 'VW')

// Reverse
cars.reverse();

console.log(cars);

// Sort and Compare

let numbers = [6, 3, 10, 9].sort((a, b) => a - b);
console.log(numbers);

cars.sort((a, b) => a.localeCompare(b));
console.log(cars);

//--------Accessor methods------------

// Join

console.log(numbers.join(", "));

// Concat

const num1 = [0, 1, 2, 3]
const num2 = [4, 5, 6]
const newNum = num1.concat(num2);

console.log(newNum);

// Slice
let sliced = num1.slice(1, 3);
console.log(sliced);

// Includes
let include = sliced.includes(1);
console.log(include);

// Index Of
let index = sliced.indexOf(2);
console.log("Index : " + index);


// ---------Iteration Methods--------

// For of
let sum = 0 

for(let num in num1){
    sum += Number(num)
}
console.log("Sum: "+ sum);

// Map
let mapArr = [1, 2, 3];
let doubledNumbers = mapArr.map((x) => Math.pow(x, 2))

console.log("Map : " + doubledNumbers);
