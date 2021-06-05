function solve(text, crtieria) {
    let parsedJson = JSON.parse(text);
    let input = crtieria.split('-');
    let result = parsedJson.reduce((acc, el) => {
        if (Object.keys(el).some(key => key == input[0] && el[key] == input[1])) {
            acc.push({
                firstName: el['first_name'],
                lastName: el['last_name'],
                email: el.email,
            });
        } else if (input[0] == 'all') {
            acc.push({
                firstName: el['first_name'],
                lastName: el['last_name'],
                email: el.email,
            });
        }
        return acc;
    }, []);
    result.forEach((x, i) => {
        console.log(`${i}. ${x.firstName} ${x.lastName} - ${x.email}`);
    });
}
const json = `[{
    "id": "1",
    "first_name": "Kaylee",
    "last_name": "Johnson",
    "email": "k0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Johnson",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  }, {
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }, {
    "id": "4",
    "first_name": "Evanne",
    "last_name": "Johnson",
    "email": "ev2@hostgator.com",
    "gender": "Male"
  }]`;

const criteria = 'last_name-Johnson';
solve(json, criteria);
