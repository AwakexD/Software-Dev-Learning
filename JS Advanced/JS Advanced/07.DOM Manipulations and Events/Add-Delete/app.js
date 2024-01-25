function addItem() {
    let itemsListElement = document.getElementById('items');
    let inputElement = document.getElementById('newItemText').value;

    let itemLiElement = document.createElement('li');
    itemLiElement.textContent = inputElement;

    inputElement = '';

    let deleteElement = document.createElement('a');
    deleteElement.href = "#"
    deleteElement.textContent = '[Delete]'
    deleteElement.addEventListener('click', (e) => {
        e.currentTarget.parentElement.remove()
    });

    itemLiElement.appendChild(deleteElement);
    itemsListElement.appendChild(itemLiElement);
}