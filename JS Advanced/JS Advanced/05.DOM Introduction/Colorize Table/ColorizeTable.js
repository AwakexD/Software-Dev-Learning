function colorize() {
    let tableElements = document.querySelectorAll('tr');

    let tableArr = Array.from(tableElements);

    tableArr.forEach((element, index) => {
        if (index % 2 != 0) {
            element.style.backgroundColor = 'teal';
        }
    });
}