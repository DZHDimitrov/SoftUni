function solve() {
  let parent = document.getElementById('quizzie').addEventListener('click', answer);
  let rightAnswers = ['onclick', 'JSON.stringify()', 'A programming API for HTML and XML documents'];
  let givenAnswers = [];
  function answer(ev) {
    if (ev.target.tagName == 'P') {
      let currentSection = ev.target.parentNode.parentNode.parentNode.parentNode;
      givenAnswers.push(ev.target.textContent);
      let nextSection = currentSection.nextElementSibling;
      currentSection.style.display = 'none';
      console.log(nextSection);
      if (nextSection.tagName == 'SECTION') {
        nextSection.style.display = 'block';
      } else {
         let resultElement = document.querySelector('.results-inner h1');
         nextSection.style.display = 'block';
         let counter = 0;
         let rightAnswersCount = givenAnswers.forEach(x => {
            if (rightAnswers.includes(x)) {
              counter++;
            }
         });
         if (counter == 3) {
           resultElement.textContent = 'You are recognized as top JavaScript fan!'
         } else {
           resultElement.textContent = `You have ${counter} right answers`
         }
      }
    }
  }
}
