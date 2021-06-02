function solve() {
  let conventionElement = document.getElementById('naming-convention');
  let resultElement = document.getElementById('result');
  let requiredConvention = conventionElement.value;
  let textElement = document.getElementById('text');
  let words = textElement.value.split(' ');
  console.log(words);
  if (requiredConvention == 'Camel Case') {
    for (let i = 0; i < words.length; i++) {
      if (i == 0) {
        words[i] = words[i][0].toLowerCase() + `${Array.from(words[i]).slice(1, words[i].length).join('').toLowerCase()}`;
      } else {
        words[i] = words[i][0].toUpperCase() + `${Array.from(words[i]).slice(1, words[i].length).join('').toLowerCase()}`;
      }
    }
    resultElement.innerHTML = words.join('');
  } else if (requiredConvention == 'Pascal Case') {
    for (let i = 0; i < words.length; i++) {
      words[i] = words[i][0].toUpperCase() + `${Array.from(words[i]).slice(1, words[i].length).join('').toLowerCase()}`
    }

    resultElement.innerHTML = words.join('');
  } else {

    resultElement.innerHTML = 'Error!';
  }
}