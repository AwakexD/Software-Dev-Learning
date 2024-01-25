const baseURL = 'http://localhost:3030/jsonstore/collections/students';

const fromELement = document.getElementById('form');

fromELement.addEventListener('submit', async(event) => {
    event.preventDefault();
    
    const formData = new FormData(event.target);
    const {firstName, lastName, facultyNumber, grade} = Object.fromEntries(formData);
    

    let data = {
        firstName,
        lastName,
        facultyNumber,
        grade : Number(grade)
    }

    try {
        let res = await fetch(baseURL, {
            method : 'POST',
            headers : {
                'content-type' : 'application/json'
            },
            body : JSON.stringify(data)
        });

        LoadStudentsAync();

    } catch (error) {
        console.log(error);
    }

    event.target.reset();
})

async function LoadStudentsAync() {
    try {
        const res = await fetch(baseURL);
        const data = await res.json();
        const tableBody = document.querySelector('#results tbody');
        tableBody.innerHTML = '';
    
        Object.values(data).forEach(student => {
            let tableRow = document.createElement('tr');
    
            tableRow.appendChild(createTableData(student.firstName));
            tableRow.appendChild(createTableData(student.lastName));
            tableRow.appendChild(createTableData(student.facultyNumber));
            tableRow.appendChild(createTableData(student.grade));

            tableBody.appendChild(tableRow);
        })
    } catch (error) {
        console.log(error);
    }
} 

function createTableData(text) {
    let tableData = document.createElement('td');
    tableData.textContent = text;

    return tableData;
}