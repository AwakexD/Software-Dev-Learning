function lockedProfile() {
    const userProfilesElements = document.querySelectorAll('.profile button');

    Array.from(userProfilesElements).forEach(btn => {
        btn.addEventListener('click', (event) => {
            const parentElement = event.target.parentElement;
            
            const radioElement = parentElement.querySelector('input[value="unlock"]');
            if (radioElement.checked) {
                let hiddenElement = parentElement.querySelector('div')

                hiddenElement.style.display === "block"
                    ? (hiddenElement.style.display = 'none')
                    : (hiddenElement.style.display = 'block');

                event.target.textContent === 'Show more'
                    ? (event.target.textContent = 'Hide it')
                    : (event.target.textContent = 'Show more');
            }
        })
    });
}