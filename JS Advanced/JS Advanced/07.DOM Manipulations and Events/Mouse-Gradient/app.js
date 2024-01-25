function attachGradientEvents() {
    let gradientElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    gradientElement.addEventListener('mousemove', (event) => {
        let percent = Math.round(event.offsetX / event.target.offsetWidth * 100);
         
        resultElement.textContent = `${percent}%`;
    })
}