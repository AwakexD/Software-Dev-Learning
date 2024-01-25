async function attachEvents() {
    const conditions = {
        Sunny: '&#x2600',
        'Partly sunny': '&#x26C5',
        Overcast: '&#x2601',
        Rain: '&#x2614',
        Degrees: '&#176;',
    };

    document.getElementById('submit').addEventListener('click', async () => {
        document.getElementById('forecast').style.display = 'block';
        let locationInput = document.getElementById('location').value;
        let locationCode;

        try {
            locationCode = await searchLocation(locationInput);
            console.log(locationCode);
        } catch (error) {
            document.getElementById('forecast').textContent = 'Error';
            return;
        }

        const todayWeather = await getTodayWeather(locationCode); 

        const forecastDiv = document.createElement('div')
        forecastDiv.classList.add('forecasts')

        const conditionSymbol = document.createElement('span');
        conditionSymbol.classList.add(['condition', 'symbol']);
        conditionSymbol.innerHTML = conditions[todayWeather.forecast.condition];
        forecastDiv.appendChild(conditionSymbol);

        const conditionSpan = document.createElement('span');
        conditionSpan.classList.add('condition');

        conditionSpan.appendChild(
            createElement('span', {classList: ['forecast-data']}, todayWeather.name)
        );

        conditionSpan.appendChild(
            createElement('span', {classList: ['forecast-data']},
                `${todayWeather.forecast.low}&#176;/${todayWeather.forecast.high}${conditions.Degrees}`
            )
        );

        conditionSpan.appendChild(
            createElement('span', {classList: ['forecast-data']}, todayWeather.forecast.condition)
        );

        forecastDiv.appendChild(conditionSpan);
        document.getElementById('current').appendChild(forecastDiv);

        // 3-Day forecast div
        const upcomingWeather = await getUpcomingWeather(locationCode); 
        const upcomingDiv = document.getElementById('upcoming');

        
        const forecastInfoDiv = createElement('div', {classList : ['forecast-info']});

        upcomingWeather.forecast.forEach(day => {
            const upcoming = createElement('span', {classList : ['upcoming']});

            upcoming.appendChild(createElement('span', {classList : ['symbol']}, conditions[day.condition]));
            upcoming.appendChild(createElement('span', {classList : ['forecast-data']}, `${day.low}${conditions.Degrees}/${day.high}${conditions.Degrees}`));
            upcoming.appendChild(createElement('span', {classList : ['forecast-data']}, day.condition));

            forecastInfoDiv.appendChild(upcoming);
        });

        upcomingDiv.appendChild(forecastInfoDiv);
    })

    async function searchLocation(location) {
        const res = await fetch('http://localhost:3030/jsonstore/forecaster/locations');
        const data = await res.json();

        const foundLocation = data.find(city => city.name.toLowerCase() === location.toLowerCase());
        console.log(foundLocation);
        if (foundLocation) {
            return foundLocation.code;
        }

        throw new Error('Location not found');
    }

    async function getTodayWeather(code) {
        const res = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${code}`);

        return await res.json();
    }

    async function getUpcomingWeather(code) {
        const res = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${code}`);

        return await res.json();
    }

    function createElement(tagName, attributes, innerText) {
        const element = document.createElement(tagName);
        if (attributes) {
            for (const key in attributes) {
                element.setAttribute(key, attributes[key]);
            }
        }
        if (innerText) {
            element.innerText = innerText;
        }
        return element;
    }
}

attachEvents();
