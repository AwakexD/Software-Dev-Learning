class Company {
    #erorrMessage;

    constructor() {
        this.deprtments = {};
        this.#erorrMessage = 'Invalid input!';
    }

    addEmployee(name, salary, position, department) {
        Array.from(arguments).forEach(param => {
            this.isValidParameter(param);
        });

        if (salary < 0) {
            throw new Error(this.#erorrMessage);
        }

        if (!this.deprtments.hasOwnProperty(department)) {
            this.deprtments[department] = [];
        } 

        this.deprtments[department].push({
            name,
            salary,
            position
        });

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment() {
        const averageDepartments = {};

        Object.keys(this.deprtments).forEach((key) => {
        const average =
            this.deprtments[key].reduce((acc, curr) => acc + curr.salary, 0) /
            this.deprtments[key].length;

        averageDepartments[key] = average;
        });

        const sorted = Object.entries(averageDepartments).sort(
        (a, b) => b[1] - a[1]
        );

        console.log(sorted);
        let result = `Best Department is: ${sorted[0][0]}\nAverage salary: ${sorted[0][1].toFixed(2)}`;

        this.deprtments[sorted[0][0]]
        .sort((a, b) => b.salary - a.salary || a.name.localeCompare(b.name))
        .forEach(
            (employee) =>
            (result += `\n${employee.name} ${employee.salary} ${employee.position}`)
        );

        return result;
    }

    isValidParameter(param) {
        if (param === ''|| param === undefined || param === null) {
            throw new Error(this.#erorrMessage);
        }
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


