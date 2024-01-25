// Multiline Object
const person = {
    name : "Ivan",
    age : 16,
    isAdult: () => this.age >= 18
};

console.log(person.isAdult()); 

// Destructoring Assingment Syntax

let {name, age} = person;
console.log(name, age); 

// Clone Object
let {...clonedPerson} = person;
clonedPerson.name = "Pesho";
console.log(clonedPerson);

// Comparing objects
let person1 = {name : 'Pesho'}
let person2 = {name : 'Pesho'}
console.log(person1 == person2);

// Associative Array
let phones = {
    'Ivan Petrov': '783921321231',
    'Georgi Georgiev': '812341783924',
    'Petar Petrov': '123543653734', 
};

// Iteration 
for (key in phones) {
    console.log(`${key} - ${phones[key]}`);
}

let names = Object.keys(phones);
let phoneNumbers = Object.values(phones);

Object.keys(phoneNumbers).forEach(x => {
    console.log(`${x} - ${phones[x]}`);
})

// Convert JSON to object
let jsonPerson = JSON.stringify(person);
console.log(typeof jsonPerson);