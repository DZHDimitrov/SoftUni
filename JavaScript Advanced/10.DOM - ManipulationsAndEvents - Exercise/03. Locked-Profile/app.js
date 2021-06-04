function lockedProfile() {
    let profileElements = Array.from(document.querySelectorAll('.profile'));

    profileElements.forEach(x=> {
        x.querySelector('button').addEventListener('click',showMore)
    });

    function showMore() {
        let profile = Array.from(this.parentNode.querySelectorAll('[type="radio"]')).filter(x=> x.checked == true);
        console.log(profile[0].value);
        if (this.textContent == 'Show more' && profile[0].value != 'lock') {
            this.previousElementSibling.style.display = 'block';
            this.textContent = 'Hide it';
        } else if (this.textContent == 'Hide it' && profile[0].value != 'lock'){
            this.previousElementSibling.style.display = 'none';
            this.textContent = 'Show more'
        }
    }
}