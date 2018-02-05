function scoreHTML(jsonArr){

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
    let json = JSON.parse(jsonArr);
    let html = '<table>\n<tr><th>name</th><th>score</th></tr>\n';
    for (let obj of json) {
        let name = escapeHtml(obj.name);
        let score = obj.score;

        html += `<tr><td>${name}</td><td>${score}</td></tr>\n`
    }
    html+='</table>';
    console.log(html);



}
scoreHTML('[{"name":"Pesho & Kiro","score":479},{"name":"Gosho, Maria & Viki","score":205}]');