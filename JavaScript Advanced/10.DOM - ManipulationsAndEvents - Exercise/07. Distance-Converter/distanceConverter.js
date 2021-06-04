function attachEventsListeners() {
    let button = document.getElementById('convert');
    button.addEventListener('click', convert);

    function convert() {
        let options = Array.from(document.querySelectorAll('#inputUnits option')).filter(x=> x.selected == true);
        let from = options[0].textContent;

        let requiredOptions = Array.from(document.querySelectorAll('#outputUnits option')).filter(x=> x.selected == true);
        let to = requiredOptions[0].textContent;

        let inputDistance = Number(document.getElementById('inputDistance').value);
        let result = calculate(from,to,inputDistance);

        let output = document.getElementById('outputDistance');
        output.value = result;



        function calculate (from,to,input) { 
            if (from == 'Kilometers' && to == 'Kilometers') {
                return input;
            } else if (from == 'Kilometers' && to == 'Meters') {
                return input * 1000;
            } else if (from == 'Kilometers' && to == 'Centimeters') {
                return input * 100000;
            } else if (from == 'Kilometers' && to == 'Millimeters') {
                return input * 1000000;
            } else if (from == 'Kilometers' && to == 'Miles') {
                return input * 0.621;
            } else if (from == 'Kilometers' && to == 'Yards') {
                return input *1093;
            } else if (from == 'Kilometers' && to == 'Feet') {
                return input * 3280;
            } else if (from == 'Kilometers' && to == 'Inches') {
                return input * 39370;
            }
            if (from == 'Meters' && to == 'Kilometers') {
                return input * 0.001;
            } else if (from == 'Meters' && to == 'Meters') {
                return input;
            } else if (from == 'Meters' && to == 'Centimeters') {
                return input * 100;
            } else if (from == 'Meters' && to == 'Millimeters') {
                return input * 1000;
            } else if (from == 'Meters' && to == 'Miles') {
                return input * 0.0006;
            } else if (from == 'Meters' && to == 'Yards') {
                return input * 1.09361;
            } else if (from == 'Meters' && to == 'Feet') {
                return input * 3.28084;
            } else if (from == 'Meters' && to == 'Inches') {
                return input * 39.3701;
            }
            if (from == 'Centimeters' && to == 'Kilometers') {
                return input / 100000;
            } else if (from == 'Centimeters' && to == 'Meters') {
                return input * 0.01;
            } else if (from == 'Centimeters' && to == 'Centimeters') {
                return input;
            } else if (from == 'Centimeters' && to == 'Millimeters') {
                return input * 10;
            } else if (from == 'Centimeters' && to == 'Miles') {
                return input / 160934;
            } else if (from == 'Centimeters' && to == 'Yards') {
                return input * 0.0109361;
            } else if (from == 'Centimeters' && to == 'Feet') {
                return input * 0.0328084;
            } else if (from == 'Centimeters' && to == 'Inches') {
                return input * 0.393701;
            }
            if (from == 'Millimeters' && to == 'Kilometers') {
                return input / 1000000;
            } else if (from == 'Millimeters' && to == 'Meters') {
                return input * 0.001;
            } else if (from == 'Millimeters' && to == 'Centimeters') {
                return input * 0.1;
            } else if (from == 'Millimeters' && to == 'Millimeters') {
                return input;
            } else if (from == 'Millimeters' && to == 'Miles') {
                return input / 1609344;
            } else if (from == 'Millimeters' && to == 'Yards') {
                return input * 0.00109361;
            } else if (from == 'Millimeters' && to == 'Feet') {
                return input * 0.00328084;
            } else if (from == 'Millimeters' && to == 'Inches') {
                return input * 0.0393701;
            }
            if (from == 'Miles' && to == 'Kilometers') {
                return input * 1.60934;
            } else if (from == 'Miles' && to == 'Meters') {
                return input * 1609.34;
            } else if (from == 'Miles' && to == 'Centimeters') {
                return input * 160934;
            } else if (from == 'Miles' && to == 'Millimeters') {
                return input * 0.000000621371192;
            } else if (from == 'Miles' && to == 'Miles') {
                return input;
            } else if (from == 'Miles' && to == 'Yards') {
                return input * 1760;
            } else if (from == 'Miles' && to == 'Feet') {
                return input * 5280;
            } else if (from == 'Miles' && to == 'Inches') {
                return input * 63360;
            }
            if (from == 'Yards' && to == 'Kilometers') {
                return input * 0.0009144;
            } else if (from == 'Yards' && to == 'Meters') {
                return input * 0.9144;
            } else if (from == 'Yards' && to == 'Centimeters') {
                return input * 91.44;
            } else if (from == 'Yards' && to == 'Millimeters') {
                return input * 914.4;
            } else if (from == 'Yards' && to == 'Miles') {
                return input * 0.000568182;
            } else if (from == 'Yards' && to == 'Yards') {
                return input;
            } else if (from == 'Yards' && to == 'Feet') {
                return input * 3;
            } else if (from == 'Yards' && to == 'Inches') {
                return input * 36;
            }
            if (from == 'Feet' && to == 'Kilometers') {
                return input * 0.0003048;
            } else if (from == 'Feet' && to == 'Meters') {
                return input * 0.3048;
            } else if (from == 'Feet' && to == 'Centimeters') {
                return input * 30.48;
            } else if (from == 'Feet' && to == 'Millimeters') {
                return input * 304.8;
            } else if (from == 'Feet' && to == 'Miles') {
                return input * 0.000189394;
            } else if (from == 'Feet' && to == 'Yards') {
                return input * 0.333333;
            } else if (from == 'Feet' && to == 'Feet') {
                return input;
            } else if (from == 'Feet' && to == 'Inches') {
                return input * 12;
            }
            if (from == 'Inches' && to == 'Kilometers') {
                return input / 39370;
            } else if (from == 'Inches' && to == 'Meters') {
                return input * 0.0254;
            } else if (from == 'Inches' && to == 'Centimeters') {
                return input * 2.54;
            } else if (from == 'Inches' && to == 'Millimeters') {
                return input * 25.4;
            } else if (from == 'Inches' && to == 'Miles') {
                return input / 63360;
            } else if (from == 'Inches' && to == 'Yards') {
                return input * 0.0277778;
            } else if (from == 'Inches' && to == 'Feet') {
                return input * 0.0833333;
            } else if (from == 'Inches' && to == 'Inches') {
                return input;
            }
            
        }
    }
}