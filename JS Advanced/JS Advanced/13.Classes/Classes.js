class Cat {
    constructor(name) {
        this.name = name
    }

    makeSound() {
        console.log('Meow');
    }
}

let catNames = [
    'Garry', 'Navcho', 'BlackCat'
]

let cats = catNames.map(x => new Cat(x));
cats.forEach(x =>  x.makeSound())