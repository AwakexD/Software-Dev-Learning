function Person(firstName, lastName) {
    const person = {
        firstName,
        lastName,
    }

    Object.defineProperty(person, 'fullName', {
        enumerable: true,
        configurable: true,
        get() {
            return `${this.firstName} ${this.lastName}`
        },
        set(value) {
            if (!value) {
                return
            }

            let[firstName, lastName] = value.split(" ");
            this.firstName = firstName;
            this.lastName = lastName;
        }
    })

    return person;
} 

let person = new Person("Peter", "Ivanov");
console.log(person.fullName); //Peter Ivanov
person.firstName = "George";
console.log(person.fullName); //George Ivanov
person.lastName = "Peterson";
console.log(person.fullName); //George Peterson
person.fullName = "Nikola Tesla";
console.log(person.firstName); //Nikola
console.log(person.lastName); //Tesla
