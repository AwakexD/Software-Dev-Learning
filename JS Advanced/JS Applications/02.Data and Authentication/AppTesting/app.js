let formElement = document.getElementById('login-form');

formElement.addEventListener('submit', (e) => {
    e.preventDefault();

    let formData = new FormData(e.currentTarget)
    let {username, password} = Object.fromEntries(formData);

    let data = {
        email : username,
        password
    }

    fetch('http://localhost:3030/users/login', {
        method : 'POST',
        headers : {
            'content-type' : 'application/json'
        },
        body : JSON.stringify(data),
    })
      .then(res => res.json())
      .then(user => {
        console.log(user);
        console.log(`Access token : ${user.accessToken}`);
      })
      .catch(err => console.log(err))
})