function solve() {
   let buttonElement = document.getElementsByTagName('button')[0];
   buttonElement.addEventListener('click',chat);
   function chat() {
         let parent = document.querySelector('#chat_messages')
         let element = document.querySelector('.my-message');
         let inputElementHTML = document.querySelector('#chat_input').value;

         let newElement = element.cloneNode();
         newElement.innerHTML = inputElementHTML;
         document.querySelector('#chat_input').value = '';

         parent.appendChild(newElement);
   }
}

