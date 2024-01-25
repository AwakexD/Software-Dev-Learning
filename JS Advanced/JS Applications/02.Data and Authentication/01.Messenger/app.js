function attachEvents() {
    const baseUrl = 'http://localhost:3030/jsonstore/messenger';
    const chatArea = document.getElementById('messages');
    
    // Send message button
    document.getElementById('submit').addEventListener('click', () => {
        const [author, message] = Array.from(document.querySelectorAll('input')).map(x => x.value);
        
        let data = {
            author,
            content: message,
        }

        fetch(baseUrl, {
            method : 'POST',
            headers : {
                'content-type' : 'application/json'
            },
            body : JSON.stringify(data),
        })
            .then(res => res.json())
            .then(data => {
                chatArea.value += `${author}: ${message} \n`;
            })
            .catch(err => console.alert(err))
    });

    // Refresh button
    document.getElementById('refresh').addEventListener('click', () => {
        chatArea.value = '';

        fetch(baseUrl)
            .then(res => res.json())
            .then(data => {
                Object.values(data).forEach(message => {
                    chatArea.value += `${message.author}: ${message.content} \n`;
                });
            })
            .catch(err => console.log(err))
    })
    
}

attachEvents();