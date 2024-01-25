function validate() {
    const inputElement = document.getElementById('email');

    inputElement.addEventListener('change', () => {
        if (isValidEmail(inputElement.value)) {
            event.target.classList.remove('error');
        } else {
            event.target.classList.add('error');
        }
    });

    let isValidEmail = (email) => {
        if (/^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/.test(email)) {
            return true;
        }
  
        return false
    }
}