
function attachEventsListeners() {
    let daysInput = document.getElementById('days');
    let hoursInput = document.getElementById('hours');
    let minutesInput = document.getElementById('minutes');
    let secondsInput = document.getElementById('seconds');

    function convertDays() {
        let days = daysInput.value;
        let seconds = days * 86400;
        let minutes = days * 1440;
        let hours = days * 24;


        updateInputs(days,hours,minutes,seconds);
    }

    function convertHours(){
        let hours =hoursInput.value;
        let days = hours / 24;
        let minutes = hours * 60;
        let seconds = hours * 3600;

        updateInputs(days,hours,minutes,seconds);
    }
    function convertMinutes(){
        let minutes = minutesInput.value;
        let days = minutes / 1440;
        let hours = minutes / 60;
        let seconds = minutes * 60;
        updateInputs(days,hours,minutes, seconds);

    }
    function convertSeconds(){
        let seconds = secondsInput.value;
        let days = seconds / 86400;
        let hours = seconds / 3600;
        let minutes = seconds / 60;
        updateInputs(days,hours,minutes,seconds)
    }

    function updateInputs(days,hours,minutes,seconds){

        daysInput.value = days;
        hoursInput.value = hours;
        minutesInput.value = minutes;
        secondsInput.value = seconds;
    }

    document.getElementById('daysBtn').addEventListener('click',convertDays);
    document.getElementById('hoursBtn').addEventListener('click',convertHours);
    document.getElementById('minutesBtn').addEventListener('click',convertMinutes);
    document.getElementById('secondsBtn').addEventListener('click',convertSeconds);

}
