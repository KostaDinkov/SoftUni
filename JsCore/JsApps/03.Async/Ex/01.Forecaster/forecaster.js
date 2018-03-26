function attachEvents() {

    let $location = $('#location');
    let $forecastData;
    let $symbol;
    let $upcommingForecastData;

    let conditions = {
        Sunny: "&#x2600", // ☀
        "Partly sunny": "&#x26C5", // ⛅
        Overcast: "&#x2601", // ☁
        Rain: "&#x2614", // ☂
        Degrees: "&#176"   // °

    };

    $('#submit').on('click', getData);

    function getData() {

        let url = `https://judgetests.firebaseio.com/locations.json`;
        $.ajax(url)
            .then(getCode)
            .then(getToday)
            .then(getThreeDay)
            .catch(onError);
    }

    function getCode(data) {
        let location = $location.val();
        let result = data.filter((obj) => obj.name === location);
        $("#forecast").css('display', '');
        if (result.length === 0) {
            throw new Error('Location not found');
        }
        return result[0].code;
    }

    function getToday(code) {
        //console.log(result[0].code);

        let url = `https://judgetests.firebaseio.com/forecast/today/${code}.json`
        $.ajax(url).then(displayToday).catch(onError);
        return code;

    }

    function getThreeDay(code) {

        let url = `https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`;
        $.ajax(url).then(displayThreeDay).catch(onError);
        return code;
    }

    function displayToday(data) {
        let $current = $("#current");
        if ($forecastData) {
            $forecastData.remove();
        }
        if ($symbol) {
            $symbol.remove();
        }
        $forecastData = $($('<span class="condition"></span>')
            .append($(`<span class = "forecast-data">${data.name}</span>`))
            .append($(`<span class = "forecast-data">${data.forecast.low}&#176/${data.forecast.high}&#176</span>`))
            .append($(`<span class="forecast-data">${data.forecast.condition}</span>`)));

        $symbol = $(`<span class="condition symbol">${conditions[data.forecast.condition]}</span>`);

        $current.append($symbol);
        $current.append($forecastData);

    }

    function displayThreeDay(data) {

        let $upcoming = $('#upcoming');
        let html = [];
        if ($upcommingForecastData) {
            $upcommingForecastData.remove();
        }

        data.forecast.forEach((obj) => {
            html.push("<span class = 'upcoming'>" +
                `<span class = "symbol">${conditions[obj.condition]}</span>` +
                `<span class = "forecast-data">${obj.low}&#176/${obj.high}&#176</span>` +
                `<span class = "forecast-data">${obj.condition}</span>` +
                "</span>");
        });
        $upcommingForecastData = $(html.join(''));
        $upcoming.append($upcommingForecastData);
    }

    function onError(e) {
        console.log('Error:\n', e);
        if ($forecastData) {
            $forecastData.remove();
        }
        if ($upcommingForecastData) {
            $upcommingForecastData.remove();
        }
        if ($symbol) {
            $symbol.remove();
        }
        $forecastData = $(`<span>Error:  ${e.message}</span>`);
        $("#current").append($forecastData);
    }
}