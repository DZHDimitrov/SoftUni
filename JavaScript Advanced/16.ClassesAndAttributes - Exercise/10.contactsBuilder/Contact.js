function solve() {
    class Contact {
        constructor(firstName, lastName, phone, email) {
            this.firstName = firstName,
                this.lastName = lastName,
                this.phone = phone,
                this.email = email;
            this.online = false;
        }

        render(id) {
            let mainElement = document.getElementById(id);
            let article = this.createEl('article');
            let divTitle = this.createEl('div', `${this.firstName} ${this.lastName}`, { class: 'title' });
            let btn = this.createEl('button', 'i');
            btn.addEventListener('click', () => {
                if (divInfo.style.display == 'none') {
                    divInfo.style.display = 'block';
                } else {
                    divInfo.style.display = 'none';
                }
            });
            let p = this.createEl('p',this.online);
            p.style.display = 'hidden';
            p.addEventListener('change', () => {
                divTitle.style.backgroundColor = 'green';
            });
            divTitle.appendChild(p);
            

            divTitle.appendChild(btn);
            article.appendChild(divTitle);
            let divInfo = this.createEl('div', undefined, { class: 'info' });
            let spanPhone = this.createEl('span', this.phone);
            let spanEmail = this.createEl('span', this.email);
            divInfo.appendChild(spanPhone);
            divInfo.appendChild(spanEmail);
            divInfo.style.display = 'none';
            article.appendChild(divInfo);
            mainElement.appendChild(article);

        }
        createEl(tag, textContent, attributes) {
            let currentElement = document.createElement(tag);
            if (textContent) {
                currentElement.textContent = textContent;
            }
            if (attributes) {
                for (const [key, value] of Object.entries(attributes)) {
                    currentElement.setAttribute(key, value);
                }
            }
            return currentElement;
        }
    }

    let contacts = [
        new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
        new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
        new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
    ];
    contacts.forEach(c => c.render('main'));

    contacts[1].online = true;
}

