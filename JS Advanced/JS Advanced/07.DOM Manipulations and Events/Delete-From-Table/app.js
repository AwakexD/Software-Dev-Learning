function deleteByEmail() {
    let emailInputElement = document.querySelector('input[name="email"]').value;
    let emailCellElement = document.querySelectorAll('tr td:nth-of-type(2)');
    let resultElement = document.getElementById('result');

    let targetElelement = Array.from(emailCellElement).find(x => x.textContent === emailInputElement);

    if (targetElelement) {
        targetElelement.parentNode.remove();
        resultElement.textContent = 'Deleted.';

    } else {
        resultElement.textContent = 'Not found.';
    }
}