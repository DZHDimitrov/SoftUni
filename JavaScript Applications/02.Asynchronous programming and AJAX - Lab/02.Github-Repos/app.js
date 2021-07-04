async function loadRepos() {
	let username = document.getElementById('username').value;
	let url = `https://api.github.com/users/${username}/repos`;
	let ulElement = document.getElementById('repos');
	Array.from(ulElement.children).forEach(x => x.remove());

	try {
		const response = await fetch(url);
		if (!response.ok) {
			throw new Error('Not found!');
		}

		const data = await response.json();
		data.forEach(x => {
			let liElement = document.createElement('li');
			let aElement = document.createElement('a');
			aElement.setAttribute('href', `${x.html_url}`);
			aElement.textContent = x.full_name;

			liElement.appendChild(aElement);
			ulElement.appendChild(liElement);
		});

	}

	catch (error) {
		let liElement = document.createElement('li');
		liElement.textContent = error.message;
		ulElement.appendChild(liElement);
	}
}