function jsonToHtml(jsonStr){

    let json = JSON.parse(jsonStr);
    let html = '<table>\n';
    let props = Object.getOwnPropertyNames(json[0]);
    html +='<tr>';
    for (let prop of props) {
        html+= `<th>${prop}</th>`
    }
    html +="</tr>\n";

    for (let obj of json) {
        html+='<tr>';
        for (let key in obj) {
            let value = escapeHtml(obj[key]);
            html+=`<td>${value}</td>`
        }
        html+='</tr>\n';

    }
    html+='</table>';
    console.log(html);
    function escapeHtml (string) {
        let entityMap = {
            '&': '&amp;',
            '<': '&lt;',
            '>': '&gt;',
            '"': '&quot;',
            "'": '&#39;',
            '/': '&#x2F;',
            '`': '&#x60;',
            '=': '&#x3D;'
        };
        return String(string).replace(/[&<>"'`=]/g, function (s) {
            return entityMap[s];
        });
    }

}

jsonToHtml('[{"Name":"Pesho <div>-a","Age":20,"City":"Sofia"},\n' +
    '{"Name":"Gosho","Age":18,"City":"Plovdiv"},{"Name":"Angel","Age":18,"City":"Veliko Tarnovo"}]\n');