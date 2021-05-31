function createArticle() {
	let titleElement = document.getElementById('createTitle');
	let textAreaElement = document.getElementById('createContent');

	if (titleElement.value && textAreaElement.value) {
		let divElement = document.createElement('article');
		let h3Element = document.createElement('h3');
		h3Element.textContent = titleElement.value;
		titleElement.value = '';
		let titleContentElement = document.createElement('p');
		titleContentElement.textContent = textAreaElement.value;
		textAreaElement.value = '';

		divElement.appendChild(h3Element);
		divElement.appendChild(titleContentElement);

		let articles = document.getElementById('articles');
		articles.appendChild(divElement);
	}
}