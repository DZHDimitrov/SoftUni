function lockedProfile() {
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';
    const main = document.getElementById('main');

    main.addEventListener('click',showMore)

    //AJAX request
    fetch(url)
        .then(response => response.json())
        .then(data => {
            let result = Object.values(data).map(createCard).join('');
            document.getElementById('main').innerHTML = result;
        })
        .catch(error => {
            alert('Error');
        })

    function createCard(person) {
        const card = `<div class="profile data-id=${person._id}">
        <img src="./iconProfile2.png" class="userIcon" />
        <label>Lock</label>
        <input type="radio" name="user1Locked" value="lock" checked>
        <label>Unlock</label>
        <input type="radio" name="user1Locked" value="unlock"><br>
        <hr>
        <label>${person.username}</label>
        <input type="text" name="user${main.children.length+1}Username" value="" disabled readonly />
        <div id="user${main.children.length+1}HiddenFields">
            <hr>
            <label>Email:</label>
            <input type="email" name="user1Email" value="${person.email}" disabled readonly />
            <label>Age:</label>
            <input type="number" name="user1Age" value="${person.age}" disabled readonly />
        </div>
        <button class="showMore">Show more</button>
    </div>`

        return card;
    }

    function showMore(e) {
        if (e.target.className != 'showMore') {
            return;
        }

        const parent = e.target.parentNode;
        const unlockBtn = parent.querySelector('[value="unlock"]');
        const additionalInfo = e.target.previousElementSibling;

        if (unlockBtn.checked && additionalInfo.style.display == '') {

            additionalInfo.style.display = 'block'
            e.target.textContent = 'Hide it';
            
        } else if (unlockBtn.checked && additionalInfo.style.display == 'block'){

            additionalInfo.style.display = '';
            e.target.textContent = 'Show more';
            
        }
    }
}