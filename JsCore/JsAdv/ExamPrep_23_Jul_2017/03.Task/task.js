class Task {
    static get statuses() {
        return {Overdue: '\u26A0','In Progress': '\u219D',Open: '\u2731', Complete: '\u2714', }
    }

    constructor(title, deadline) {
        this.title = title;
        this.deadline = deadline;
        this.status = 'Open';
    }

    set deadline(date){

        if(date.getTime()<Date.now()){
            throw new Error();
        }
        this._deadline = date;

    }

    get deadline(){
        return this._deadline;
    }

    get isOverdue() {

        if(this.deadline.getTime() < Date.now() ){
            return this.status !== 'Complete';
        }
        return false;

    }

    toString() {

        let icon = '';
        let deadline = ` (deadline: ${this.deadline})`;
        if (this.isOverdue) {
                icon = Task.statuses.Overdue;
                deadline = '(overdue)'
        }
        else{
            icon = Task.statuses[this.status];
        }

        if (this.status === 'Complete') {
            deadline = '';
        }
        return `[${icon}] ${this.title}${deadline}`
    }

    static comparator(a, b) {
        let keys = Object.keys(Task.statuses);

        let index_a = a.isOverdue?0:keys.indexOf(a.status);
        let index_b = b.isOverdue?0:keys.indexOf(b.status);

        if( index_a < index_b){
            return -1
        }
        else if (index_a === index_b){
            return a.deadline.getTime() - b.deadline.getTime();
        }

        return 1;

    }
}
new Task('Right now', new Date());

