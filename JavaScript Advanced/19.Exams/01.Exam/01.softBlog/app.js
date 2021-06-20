function solve(){
      let formElement = document.querySelector('.site-content form');
      let inputs = Array.from(formElement.querySelectorAll('input'));
      let textArea = formElement.querySelector('textarea');

      let resultSection = document.querySelector('.site-content main section');
      formElement.querySelector('button').addEventListener('click',add);

     

      function add(e) {
         e.preventDefault();
         let [author,title,category] = inputs.map(x=>x.value);
         let content = textArea.value;
         inputs.forEach(x=> x.value = '');
         textArea.value = '';
         let articleElement = document.createElement('article');

         let h1Element = document.createElement('h1');
         h1Element.textContent = title;

         let pCategoryElement = document.createElement('p');
         pCategoryElement.textContent='Category:';
         let strongInnerCategory = document.createElement('strong');
         strongInnerCategory.textContent = category;
         pCategoryElement.appendChild(strongInnerCategory);

         let pCreatorElement = document.createElement('p');
         pCreatorElement.textContent = 'Creator:'
         let strongInnerCreator = document.createElement('strong');
         strongInnerCreator.textContent = author;
         pCreatorElement.appendChild(strongInnerCreator);

         let pText = document.createElement('p');
         pText.textContent = content;

         let divElement = document.createElement('div');
         divElement.setAttribute('class','buttons');
         let buttonDeleteInnerDiv = document.createElement('button');
         buttonDeleteInnerDiv.setAttribute('class','btn delete');
         buttonDeleteInnerDiv.textContent = 'Delete';
         buttonDeleteInnerDiv.addEventListener('click',deleteArticle)
         let buttonArchiveInnerDiv = document.createElement('button');
         buttonArchiveInnerDiv.setAttribute('class','btn archive');
         buttonArchiveInnerDiv.textContent = 'Archive';
         buttonArchiveInnerDiv.addEventListener('click',archive);
         divElement.appendChild(buttonDeleteInnerDiv);
         divElement.appendChild(buttonArchiveInnerDiv);

         articleElement.appendChild(h1Element);
         articleElement.appendChild(pCategoryElement);
         articleElement.appendChild(pCreatorElement);
         articleElement.appendChild(pText);
         articleElement.appendChild(divElement);

         resultSection.appendChild(articleElement);
         
      }

      function deleteArticle(e) {
         e.target.parentElement.parentElement.remove();
      }
      function archive(e) {
         let archiveSectionOl = document.querySelector('.archive-section').lastElementChild;
         let title = e.target.parentElement.parentElement.firstElementChild.textContent;
         e.target.parentElement.parentElement.remove();

         let liElement = document.createElement('li');
         liElement.textContent = title;
         archiveSectionOl.appendChild(liElement);

         let liElements = sortOl(Array.from(archiveSectionOl.children));
         liElements.forEach(x=> archiveSectionOl.appendChild(x));
      }
      function sortOl(array) {
         console.log(array);
         return array.sort((a,b) => a.textContent.localeCompare(b.textContent));
      }
  }
