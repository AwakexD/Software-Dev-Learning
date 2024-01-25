function subtract() {
    let number1 = document.getElementById('firstNumber').value;
    let number2 = document.getElementById('secondNumber').value;

    let resultElement = document.getElementById('result');
    resultElement.textContent = Number(number1) - Number(number2);
}