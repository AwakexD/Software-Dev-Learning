import { renderHome } from "./home.js";
import { renderLogin } from "./Login.js";
import { renderLogout } from "./logout.js";
import { renderRegister } from "./register.js";

const routes = {
    '/': renderHome,
    '/login' : renderLogin,
    '/logout': renderLogout,
    '/register' : renderRegister,
}

export function router(path) {
    hideAll();

    const renderer = routes[path];
    renderer();
}


function hideAll() {
    document.querySelectorAll('.view-section').forEach(v => { v.style.display = 'none' });
}

