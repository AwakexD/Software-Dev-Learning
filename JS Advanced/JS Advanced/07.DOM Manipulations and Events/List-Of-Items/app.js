function addItem() {
    let input = document.getElementById('newItemText').value;
    let itemsList = document.getElementById('items');

    let newItem = document.createElement('li');
    newItem.textContent = input;

    itemsList.appendChild(newItem);
}