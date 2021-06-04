function encodeAndDecodeMessages() {
    let parent = document.getElementById('main');
    parent.addEventListener('click', encode)
    let decodedMessage = document.getElementsByTagName('textarea')[0];
    let encodedMessage = document.getElementsByTagName('textarea')[1];
    function encode(ev) {
        if (ev.target.tagName == 'BUTTON' && ev.target.textContent.includes('Encode')) {
            let textToEncode = decodedMessage.value;
            let encoded = [];
            for (let i = 0; i < textToEncode.length; i++) {
                let currentChar = textToEncode.charCodeAt(i);
                encoded.push(String.fromCharCode(currentChar + 1));
            }
            encodedMessage.value = encoded.join('');
            decodedMessage.value = '';
        } else if (ev.target.tagName == 'BUTTON' && ev.target.textContent.includes('Decode')) {
            let textToDecode = encodedMessage.value;
            let decoded = [];
            for (let i = 0; i < textToDecode.length; i++) {
                let currentChar = textToDecode.charCodeAt(i);
                decoded.push(String.fromCharCode(currentChar - 1));
            }
            encodedMessage.value = decoded.join('');
        }
    }
}