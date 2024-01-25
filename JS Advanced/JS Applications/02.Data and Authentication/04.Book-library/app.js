const baseUrl = 'http://localhost:3030/jsonstore/collections/books';


// Loading all books
document.getElementById('loadBooks').addEventListener('click', (event) => {
    const tableBody = document.querySelector('tbody');
    tableBody.innerHTML = '';

    fetch(baseUrl)
        .then(res => res.json())
        .then(data => {
            Object.values(data).forEach(book => {
                tableBody.appendChild(createTableRow(book));
            })
        })
        .catch(err => console.log(err));
})

// Adding book via form
document.querySelector('form').addEventListener('submit', (event) => {
    event.preventDefault();
    
    const formData = new FormData(event.currentTarget);
    const {author, title} = Object.fromEntries(formData);

    if (!title || !author) {
        return;
    }

    const data = {
        author,
        title,
    }

    event.target.reset();

    fetch(baseUrl, {
        method : 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body : JSON.stringify(data),
    })
        .then(res => res.json())
        .catch(err => console.log(err))


})

function createTableRow(book) {
    let tableRow = document.createElement('tr');

    let tdTitle = document.createElement('td');
    tdTitle.textContent = book.title;
    let tdAuthor = document.createElement('td');
    tdAuthor.textContent = book.author;
    tableRow.appendChild(tdTitle);
    tableRow.appendChild(tdAuthor);

    let tdButtons = document.createElement('td');

    let editButton = document.createElement('button');
    editButton.addEventListener('click', editBookAsync)
    editButton.textContent = 'Edit';

    let deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';
    deleteButton.addEventListener('click', deleteBookAsync(book._id));
   

    tdButtons.appendChild(editButton);
    tdButtons.appendChild(deleteButton);

    tableRow.appendChild(tdButtons);

    return tableRow;
} 

function editBookAsync(event) {
    console.log('edit');
}

function deleteBookAsync(id) {
    fetch(`${baseUrl}/${id}`, {
        method : 'DELETE'
    })
        .then(res => res.json())
        .then(data => {

        })
        .catch(err => console.log(err));  
}

