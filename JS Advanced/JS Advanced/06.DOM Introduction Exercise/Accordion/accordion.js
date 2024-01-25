function toggle() {
    let btn = document.getElementsByClassName('button')[0];
    let extraContent = document.getElementById('extra');

    if (btn.textContent === "More") {
        extraContent.style.display = 'block';
        btn.textContent = 'Less'

    } else {
        extraContent.style.display = 'none';
        btn.textContent = 'More'
    }
    
}