function attachEvents() {
    document.getElementById('submit').addEventListener('click', getWeather)

    const current = document.getElementById('current');
    const upcoming = document.getElementById('upcoming');
    const condition = document.getElementById('condition');

    function getWeather() {

        if (current.children.length > 1) {
            current.lastElementChild.remove();
            upcoming.lastElementChild.remove();
        }

        condition.textContent = 'Current conditions';
        upcoming.style.display = 'block';

        const inputLocation = document.getElementById('location');
        const url = 'http://localhost:3030/jsonstore/forecaster/locations';

        //AJAX request
        fetch(url)
            .then(response => response.json())
            .then(data => {

                let forecastTodayPromise =
                    forecastToday(data.find(location =>
                        location.name == inputLocation.value).code);
                let forecastUpcomingPromise =
                    forecastUpcoming(data.find(location =>
                        location.name == inputLocation.value).code);

                inputLocation.value = '';

                let promise = Promise.all([forecastTodayPromise, forecastUpcomingPromise]);
                resolvePromise(promise);
            })
            .catch(error => {
                document.getElementById('forecast').style.display = 'block';
                condition.textContent = 'Error';
                upcoming.style.display = 'none';
                
                if (current.children.length > 1) {
                    current.lastElementChild.remove();
                    upcoming.lastElementChild.remove();
                }
            })
    }

    //AJAX request. Returns promise
    function forecastToday(code) {
        const url = 'http://localhost:3030/jsonstore/forecaster/today/' + code;

        return fetch(url);
    }

    //AJAX request. Returns promise
    function forecastUpcoming(code) {
        const url = 'http://localhost:3030/jsonstore/forecaster/upcoming/' + code;

        return fetch(url);
    }

    function resolvePromise(promise) {
        promise.then(promiseAsAnArray =>

            promiseAsAnArray.forEach((response, index) =>

                response.json().then(data => {
                    if (index == 0) {
                        document.getElementById('forecast').style.display = 'block';
                        current.appendChild(createCurrentForecastDiv(data));
                    } else {
                        upcoming.appendChild(createUpcomingForecastDiv(data));
                    }
                })
            )
        )
    };

    function createCurrentForecastDiv(currentInfo) {

        const condition = currentInfo.forecast.condition;
        const high = currentInfo.forecast.high;
        const low = currentInfo.forecast.low;
        const location = currentInfo.name;

        const symbol = findSymbol(condition);

        const divElement = document.createElement('div');
        divElement.setAttribute('class', 'forecasts');

        const spanConditionSymbol = document.createElement('span');
        spanConditionSymbol.classList.add('condition', 'symbol');
        spanConditionSymbol.textContent = symbol;

        const spanCondition = document.createElement('span');
        spanCondition.classList.add('condition');

        const spanLocation = document.createElement('span');
        spanLocation.classList.add('forecast-data');
        spanLocation.textContent = location;

        const spanTemperature = document.createElement('span');
        spanTemperature.classList.add('forecast-data');
        spanTemperature.textContent = `${low}°/${high}°`;

        const spanWeather = document.createElement('span');
        spanWeather.classList.add('forecast-data');
        spanWeather.textContent = condition;

        spanCondition.appendChild(spanLocation);
        spanCondition.appendChild(spanTemperature);
        spanCondition.appendChild(spanWeather);

        divElement.appendChild(spanConditionSymbol);
        divElement.appendChild(spanCondition);
        return divElement;
    }

    function createUpcomingForecastDiv(currentInfo) {
        const forecasts = currentInfo.forecast;
        const divElement = document.createElement('div');
        divElement.classList.add('forecast-info');
        forecasts.forEach(el => {
            const symbol = findSymbol(el.condition);
            const mainSpan = document.createElement('span');
            mainSpan.classList.add('upcoming');

            const spanSymbol = document.createElement('span');
            spanSymbol.textContent = symbol;
            spanSymbol.classList.add('symbol');

            const spanTemperature = document.createElement('span');
            spanTemperature.classList.add('forecast-data');
            spanTemperature.textContent = `${el.low}°/${el.high}°`;

            const spanCondition = document.createElement('span');
            spanCondition.classList.add('forecast-data');
            spanCondition.textContent = el.condition;

            mainSpan.appendChild(spanSymbol);
            mainSpan.appendChild(spanTemperature);
            mainSpan.appendChild(spanCondition);

            divElement.appendChild(mainSpan);
        });
        return divElement;
    }

    function findSymbol(condition) {
        const symbol = condition == 'Sunny' ? '☀' :
            condition == 'Partly sunny' ? '⛅' :
                condition == 'Overcast' ? '☁' :
                    condition == 'Rain' ? '☂' : ''
        return symbol
    }
}

attachEvents();