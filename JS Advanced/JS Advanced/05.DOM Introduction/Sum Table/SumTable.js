function sumTable() {
    let productElements = document.querySelectorAll('tr td:nth-of-type(2)');
    
    let sum  = Array.from(productElements).reduce((a, x) => {
        let currentValue = Number(x.textContent) || 0;
        return a + currentValue;
    }, 0);

    let resultElement = document.getElementById('sum').textContent = sum;
}