import {postNewIdea} from '../api/data.js'

export function setCreate(section,navigation){
    section.querySelector('form').addEventListener('submit',onSubmit);
    return showCreate;
    
    async function showCreate() {
        return section
    }

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);
        const title = formData.get('title');
        const description = formData.get('description');
        const img = formData.get('imageURL');

        if (title.length < 6) {
            return alert('Title should be atleast 6 characters long!.')
        }
        if (description.length < 10) {
            return alert('Description should be atleast 10 characters long!')
        }
        if (img.length < 5) {
            return alert('Image should be atleast 5 characters long!')
        }
        const data = {title,description,img};
        await postNewIdea(data);
        navigation.changeView('dashboard');
        event.target.reset();
    }
}