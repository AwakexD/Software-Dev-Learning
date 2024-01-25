class Stringer {
    initialString = ''

    constructor(text, length) {
        this.initialString = text;
        this.innerString = text;
        this.innerLength = length;
    }

    increase(value) {
        this.innerString = this.initialString.substring(0, value);
    }

    decrease(value) {
        if (this.innerLength <= 0 || this.innerLength - value <= 0) {
            this.innerString = ''
        } else {
            this.innerString = this.innerString.substring(0, value - 1)
        }
    }

    toString() {
        if (this.innerLength === 0) {
            return '...'
        }

        return this.innerString;
    }
}


let test = new Stringer("Test", 5);
console.log(test.toString()); // Test
test.decrease(3);
console.log(test.toString()); // Te...
test.decrease(5);
console.log(test.toString()); // ...
test.increase(4);
console.log(test.toString()); // Tes