function getNumber() {
    let randomNumber = Math.random();

    if (randomNumber < 0.5) {
        //throw new Error('Your number is too low');
        throw {
            message: 'Your number is too low',
            type : 'Some_error_TYPE',
        }
    }

    return Math.floor(randomNumber * 100);
}

function app() {
    let number;

    try {
        number = getNumber();
    } catch (error) {  
        console.log(error.message + '\n' + error.type);
    }

    console.log(number);

}

app();

