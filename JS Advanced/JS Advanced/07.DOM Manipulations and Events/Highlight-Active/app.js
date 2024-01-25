function focused() {
    let sectionsElement = document.querySelectorAll('input[type="text"]');
    console.log(sectionsElement);

    sectionsElement.forEach(element => {
        element.addEventListener('focus', (e) => {
            e.target.parentElement.classList.add('focused');
        });

        element.addEventListener('blur', (e) => {
            e.target.parentElement.classList.remove('focused');
        })
    });
}