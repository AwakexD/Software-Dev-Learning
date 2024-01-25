function getInfo() {
    const inputField = document.getElementById('stopId');
    const stopName = document.getElementById('stopName');
    const busList = document.getElementById('buses');
    const submitButton = document.getElementById('submit');

    submitButton.addEventListener('click', () => {
        let stopId = inputField.value;
        let baseUrl = 'http://localhost:3030/jsonstore/bus/businfo/';

        fetch(`${baseUrl}/${stopId}`)
            .then(res => res.json())
            .then(data => {
                stopName.textContent = data.name;
                busList.innerHTML = '';

                Object.entries(data['buses']).forEach(bus => {
                    let busElement = document.createElement('li');
                    busElement.textContent = `Bus ${bus[0]} arrives in ${bus[1]} minutes`;
                    busList.appendChild(busElement);
                });
            })
            .catch(err => {
                stopName.textContent = 'Error'
            })
    });

}