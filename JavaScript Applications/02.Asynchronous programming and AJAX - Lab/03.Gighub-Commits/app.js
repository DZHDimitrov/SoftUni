async function loadCommits() {
    const username = document.getElementById('username').value;
    const repo = document.getElementById('repo').value;
    const url = `https://api.github.com/repos/${username}/${repo}/commits`;
    let ulElement = document.getElementById('commits');
    console.log(ulElement);

    try {
        let response = await fetch(url);
        if (!response.ok) {
            throw new Error(`Error: ${response.status} (Not Found)`);
        }
        let json = await response.json();
        json.forEach(obj => {
            let liElement = document.createElement('li');
            liElement.textContent = `${obj.commit.author.name}: ${obj.commit.message}`;
            ulElement.appendChild(liElement);
        });
    }
    catch (error) {
        let liElementError = document.createElement('li');
        liElementError.textContent = error.message;
        ulElement.appendChild(liElementError);
    }
}