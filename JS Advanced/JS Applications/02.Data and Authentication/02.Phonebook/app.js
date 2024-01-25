function attachEvents() {
    const url = 'http://localhost:3030/jsonstore/phonebook';
    
    // Load Button
    document.getElementById('btnLoad').addEventListener('click', () => {
        fetch(url)
            .then(res => res.json())
            .then(data => {
                const listElement = document.getElementById('phonebook');
                listElement.innerHTML = '';

                Object.values(data).forEach(record => {
                    let li = document.createElement('li');
                    li.textContent = `${record.person}:${record.phone}`

                    let deleteBtn = document.createElement('button');
                    deleteBtn.textContent = 'Delete';
                    deleteBtn.setAttribute('id', record._id);
                    deleteBtn.addEventListener('click', (event) => {deleteEntry(event)});
                    li.appendChild(deleteBtn);

                    listElement.appendChild(li);
                })
            })
            .catch(err => console.log(err));

        async function deleteEntry(event) {
           const userId =  event.currentTarget.id;

           let res = await fetch(`${url}/${userId}`, {
                method : 'DELETE'
           });

           if (!res.ok) {
                throw new Error();
           }

           event.target.parentNode.remove();
        }
    });

    // Add new contact
    document.getElementById('btnCreate').addEventListener('click', async() => {
        const [person, phone] = document.querySelectorAll('input');
        const body  = {
            person : person.value,
            phone: phone.value,
        }

        const res = await fetch(url, {
            method : 'POST',
            body : JSON.stringify(body),
        })

        person.value = '';
        phone.value  = '';
        

    })
}

attachEvents();