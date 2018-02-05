function jsonTable(input_arr) {

    let html = '<table>\n';
    for (let emp of input_arr) {

        emp = JSON.parse(emp);

        html +=
            '\t<tr>\n' +
            `\t\t<td>${emp.name}</td>\n` +
            `\t\t<td>${emp.position}</td>\n` +
            `\t\t<td>${Number(emp.salary)}</td>\n` +
            `\t<tr>\n`;
    }
    html += '</table>';
    console.log(html);
}

jsonTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}']);