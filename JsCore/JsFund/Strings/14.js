function employeeData(data){

    let re = new RegExp(/^([A-Z][a-z]+) - ([0-9][\d]*\.?\d{0,2}) - ([a-zA-Z0-9_\-\s]+)$/);



    for (let record of data) {
        let match = re.exec(record);
        if(match!==null){
            console.log(`Name: ${match[1]}\nPosition: ${match[3]}\nSalary: ${match[2]}`)
        }
    }
}

employeeData(['Isacc - 1000 - CEO','Ivan - 500 - Employee','Peter - 500 - Employee']);