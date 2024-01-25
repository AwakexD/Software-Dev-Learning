class Person {
    constructor(firstName, lastName, age, email){
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.email = email;
    }

    toString() {
       return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`
    }
}

let personInfo = [
    {firstName: 'Anna', lastName : 'Simpson', age : 22, email : 'anna@yahoo.com'},
    {firstName: 'SoftUni'},
    {firstName: 'Stephan', lastName : 'Johnson', age : 25,},
    {firstName: 'Gabriel', lastName : 'Peterson', age : 24, email : 'g.p@gmail.com'},
]

let resultArr = personInfo.map(x => new Person(x.firstName, x.lastName, x.age, x.email));

console.log(resultArr);