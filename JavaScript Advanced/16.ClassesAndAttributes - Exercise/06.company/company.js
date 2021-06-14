class Company {
    constructor() {
        this.departments = [];
    }

    addEmployee(username, salary, position, department) {
        if (!username || !salary || !position || !department || salary < 0) {
            throw new Error('Invalid input!')
        }

        const newEmployee = { username, salary, position, department };
        this.departments.push(newEmployee);
        return `New employee is hired. Name: ${newEmployee.username}. Position: ${newEmployee.position}`
    }

    bestDepartment() {
        let result = Object.entries(this.departments.reduce((acc, el) => {
            if (!acc.hasOwnProperty(el.department)) {
                acc[el.department] = { people: [], salary: 0 };
            }
            const userName = el.username;
            const salary = el.salary;
            const position = el.position;
            acc[el.department].people.push({ userName, salary, position });
            acc[el.department].salary += el.salary;
            return acc;
        }, {}))
            .reduce((acc, el) => {
                const obj = {
                    name: el[0],
                    avgSalary: (el[1].salary / el[1].people.length).toFixed(2),
                    people: el[1].people,
                }
                acc.push(obj);
                return acc;
            }, [])
            .sort((a, b) => b.avgSalary - a.avgSalary);

        let resultString = '';
        let bestDepartment = result[0];
        resultString += `Best Department is: ${bestDepartment.name}\n`;
        resultString += `Average salary: ${bestDepartment.avgSalary}\n`;
        bestDepartment.people.sort((a, b) => this._sorting(a, b)).forEach((x, i) => {
            if (i < bestDepartment.people.length - 1) {
                resultString += `${Object.values(x).join(' ')}\n`
            } else {
                resultString += `${Object.values(x).join(' ')}`
            }
        });

        
        return resultString;
    }
    _sorting(a, b) {
        if (a.salary === b.salary) {
            return a.userName.localeCompare(b.userName);
        }
        return b.salary - a.salary
    }
}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());



