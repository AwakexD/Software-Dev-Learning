import { router } from './router.js';
import { updateNav } from './auth.js';

router('/');
updateNav();

const navigationElement = document.querySelector('.navbar');
navigationElement.addEventListener('click',  (event) => {
    event.preventDefault();
    if (event.target.tagName == 'A') {
        let url = new URL(event.target.href);
        
        router(url.pathname);
    }
}) 