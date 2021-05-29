function library() {
    let obj = {
        hasClima (currentObject) {
            currentObject.temp = 21;
            currentObject.tempSettings = 21;
            currentObject.adjustTemp = function (){ 
                if (currentObject.temp < currentObject.tempSettings) {
                    currentObject.temp++;
                }
                else if (currentObject.temp > currentObject.tempSettings){
                    currentObject.temp--;
                }
            }
        },

        hasAudio (currentObject) {
            currentObject.currentTrack = null;
            currentObject.nowPlaying = function() {
                if (currentObject.currentTrack == undefined) {
                    return;
                }
                console.log(`Now playing '${currentObject.currentTrack.name}' by ${currentObject.currentTrack.artist}`);
            }
        },
        
        hasParktronic (currentObject) {
            currentObject.checkDistance = function (distance) {
                let number = Number(distance);
                let message = number < 0.1 ? 'Beep! Beep! Beep!' : 0.1 <= number && number  < 0.25 ? "Beep! Beep!" : 0.25 <= number && number <0.5 ? "Beep!" : '';
                console.log(message);
            }
        }
    }
    return obj;
}

const assemblyLine = library();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);


assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();



assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);

console.log(myCar);
