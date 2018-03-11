function solve() {
    class Employee {
        constructor(name, age) {
            if (new.target === Employee) {
                throw new Error();
            }
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
            this._currentTask = 0;
        }

        work() {
            console.log(this.tasks[this._currentTask]);
            this._currentTask++;
            if (this._currentTask >= this.tasks.length) {
                this._currentTask = 0;
            }

        }

        collectSalary() {
            console.log(`${this.name} received ${this.salary + (this.dividend || 0)} this month.`);
        }

    }


    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [`${this.name} is working on a simple task.`];
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks = [
                `${this.name} is working on a complicated task.`,
                `${this.name} is taking time off work.`,
                `${this.name} is supervising junior workers.`]
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;

            this.tasks = [
                `${this.name} scheduled a meeting.`,
                `${this.name} is preparing a quarterly report.`]
        }
    }

    return {Employee,Junior,Senior,Manager};
}

let senior = new (solve().Senior)('John',22);
senior.work();
senior.work();
senior.work();
senior.work();
senior.collectSalary();


let manager = new Manager('Bob', 33, 6000, 300);
manager.work();
manager.collectSalary();