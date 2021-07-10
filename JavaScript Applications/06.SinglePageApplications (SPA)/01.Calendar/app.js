function start() {
    const months = {
        'Jan': 1,
        'Feb': 2,
        'Mar': 3,
        'Apr': 4,
        'May': 5,
        'Jun': 6,
        'Jul': 7,
        'Aug': 8,
        'Sept': 9,
        'Oct': 10,
        'Nov': 11,
        'Dec': 12,
    }

    const body = document.body;
    const monthsCalendar = [...document.querySelectorAll('.monthCalendar')].reduce((acc, el) => {
        acc[el.id] = el
        return acc;
    }, {});
    const daysCalendar = [...document.querySelectorAll('.daysCalendar')].reduce((acc, el) => {
        acc[el.id] = el;
        return acc;
    }, {});
    const years = document.getElementById('years');

    body.innerHTML = '';
    changeView(years);

    body.addEventListener('click', (e) => {
        if (e.target.tagName == 'CAPTION') {
            const id = e.target.parentNode.parentNode.id;
            if (id.startsWith('year-')) {
                changeView(years);
            } else if (id.startsWith('month')) {
                const year = id.split('-')[1];
                const section = monthsCalendar[`year-${year}`];
                changeView(section);
            }
            return;
        }

        if (e.target.classList.contains('date') || e.target.classList.contains('day')) {
            let section = e.target.parentNode;
            while (section.tagName != 'SECTION') {
                section = section.parentNode;
            }
            if (section.classList.contains('yearsCalendar')) {
                showMonths(e)
            } else if (section.classList.contains('monthCalendar')) {
                showDays(e, section);
            }
        }
    });

    function showMonths(e) {
        let year;
        if (e.target.classList.contains('date')) {
            year = e.target.textContent;
        } else if (e.target.classList.contains('day')) {
            year = e.target.firstElementChild.textContent;
        }
        const sectionToShow = monthsCalendar[`year-${year}`];
        changeView(sectionToShow);
    }

    function showDays(e, section) {
        let month;
        if (e.target.classList.contains('date')) {
            month = e.target.textContent;
        } else if (e.target.classList.contains('day')) {
            month = e.target.firstElementChild.textContent;
        }
        const year = section.id.split('-')[1];
        const sectionToShow = daysCalendar[`month-${year}-${months[month]}`];
        changeView(sectionToShow);
    }
    
    function changeView(section) {
        body.innerHTML = '';
        body.appendChild(section);
    }
}

start();