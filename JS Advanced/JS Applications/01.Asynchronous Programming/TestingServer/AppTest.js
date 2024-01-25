const phonebookList = document.getElementById('ul-list');
const baseUrl = 'http://localhost:3030/jsonstore'

document.getElementById('load-contacts').addEventListener('click', () => {
    fetch(`${baseUrl}/phonebook`)
        .then(res => res.json())
        .then(data => {
            phonebookList.innerHTML = '';

            Object.values(data).forEach(element => {
                let newLiElement = document.createElement('li');
                newLiElement.textContent = `${element.person} - ${element.phone}`;
                phonebookList.appendChild(newLiElement)
            })
        })
        .catch(err => console.log(err));
})


document.getElementById('add-contact').addEventListener('click', () => {
    const person = document.getElementById('personInput').value;
    const phone = document.getElementById('phoneInput').value;
    
    fetch(`${baseUrl}/phonebook`, {
        method : 'POST',
        headers : {
            'content-type': 'application/json'
        },
        body : JSON.stringify({person, phone})
    })
        .then(res => {return res.json()})
        .then(contact => {
            let contactElement = document.createElement('li');
            contactElement.textContent = `${contact.person} - ${contact.phone}`;
            phonebookList.appendChild(contactElement);
        })
        .catch(err => console.log(err));
})
