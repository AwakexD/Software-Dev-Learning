import { router } from "./router.js";
import { updateNav } from "./auth.js";

const loginSection = document.getElementById('form-login');
const loginForm = loginSection.querySelector('#login-form');

const url = 'http://localhost:3030/users/login';

loginForm.addEventListener('submit', (event) => {
    event.preventDefault();

    let formData = new FormData(event.target);
    let {email, password} = Object.fromEntries(formData);

    fetch(url, {
        method: 'POST',
        headers: {
            'content-type' : 'application/json',
        },
        body : JSON.stringify({email, password}),
    })
        .then(res => res.json())
        .then(user => {
            localStorage.setItem('user', JSON.stringify(user));
            loginForm.reset();
            router('/');
            updateNav();
        })
        .catch(err => console.log(err))
})

export function renderLogin() {
    loginSection.style.display = 'block';
}