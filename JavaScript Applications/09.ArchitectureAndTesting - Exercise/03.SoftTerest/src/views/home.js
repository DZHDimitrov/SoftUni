export function setHome(section,navigation){
    section.addEventListener('click',ev => {
        if (ev.target.classList.contains('btn')) {
            ev.preventDefault();
            navigation.changeView('dashboard');
        }
    })
    return showHome;
    
    
    async function showHome() {
        return section;
    }
}