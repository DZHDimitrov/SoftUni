function extract(content) {
    let element = document.getElementById('content');
    let text = element.innerHTML;
    let word = '';
    let resultArray = [];
    for (let i = 0; i < text.length; i++) {
        if (text[i] == '(') {
            for (let j = i+1; j < text.length; j++) {
                if (text[j] == ')') {
                    resultArray.push(word);
                    word = '';
                    break;
                }
                word += text[j]
            }
        }
    }
    return resultArray.join('; ') + ';';
}