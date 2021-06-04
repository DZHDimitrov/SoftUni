function attachEventsListeners() {
    let buttons = Array.from(document.querySelectorAll('[value="Convert"]'));
    let results = Array.from(document.querySelectorAll('[type="text"]'));
    buttons.forEach(x => {
        x.addEventListener('click', convert)
    });

    function convert(ev) {
        let timeType = this.parentNode.firstElementChild.textContent;
        let clearWord = timeType.replace(':', '')
        let input = Number(this.parentNode.querySelector('[type="text"]').value);
        let dayConvertion = calculate(input, clearWord);
        Object.entries(dayConvertion).forEach((x,i)=> {
            results[i].value = x[1];
        });

    }

    function calculate(input, timeType) {
        let obj = {};
        if (timeType == 'Days') {
            obj.days = input;
            obj.hours = input * 24;
            obj.minutes = input * 1440;
            obj.seconds = input * 86400;
        } else if (timeType == 'Hours') {
            obj.days = input / 24;
            obj.hours = input;
            obj.minutes = input * 60;
            obj.seconds = input * (Math.pow(60, 2));
        } else if (timeType == 'Minutes') {
            obj.days = input / 1440;
            obj.hours = input / 60;
            obj.minutes = input;
            obj.seconds = input * 60;
        } else if (timeType == 'Seconds') {
            obj.days = input / 86400;
            obj.hours = input / 3600;
            obj.minutes = input / 60;
            obj.seconds = input;
        }
        return obj;
    }
}