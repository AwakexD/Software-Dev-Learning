function addItem() {
    let itemElementText = document.getElementById('newItemText').value;
    let itemElementValue = document.getElementById('newItemValue').value;

    let newItem = document.createElement('option');
    newItem.textContent = itemElementText;
    newItem.value = itemElementValue;

    let menu = document.getElementById('menu');
    menu.appendChild(newItem);

    itemElementText.value = '';
    itemElementValue.value = '';
}