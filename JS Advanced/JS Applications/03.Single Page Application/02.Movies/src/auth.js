import { router } from "./router.js";

const guestNavigation = document.querySelectorAll('li.nav-item.guest');
const userNavigation = document.querySelectorAll('li.nav-item.user');

export function updateNav() {
    let serializedUser = localStorage.getItem('user');
    const welcomeContainer = document.getElementById('welcome-msg');

    if (serializedUser) {
        userNavigation.forEach(li => {li.style.display = 'block'});
        guestNavigation.forEach(li => {li.style.display = 'none'});
        welcomeContainer.textContent = `Welcome, ${JSON.parse(serializedUser).email}`
    } else {
        userNavigation.forEach(li => {li.style.display = 'none'});
        guestNavigation.forEach(li => {li.style.display = 'block'});
        welcomeContainer.textContent = '';
    }
} 

export function logout() {
    localStorage.removeItem('user');
    updateNav();
    router('/')
}

