function calculator() {
    let numberElement1, numberElement2, resultElement;

    return {
        init : (selector1, selector2, resultSelector) => {
            numberElement1 = document.querySelector(selector1);
            numberElement2 = document.querySelector(selector2);
            resultElement = document.querySelector(resultSelector);
        },
        add : () => resultElement.value =+ numberElement1.value + numberElement2.value,
        subtract: () => resultElement.value =+ numberElement1.value - numberElement2.value,
    }
}




