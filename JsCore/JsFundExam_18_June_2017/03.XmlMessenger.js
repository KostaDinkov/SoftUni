function xmlMessenger(input) {

    let input_validator = new RegExp(/^<\s*message\s*(([a-z]+="[\s\w\.]+"\s*)*?>)([^]+)<\s*\/\s*message\s*>/, 'g');
    let match = input_validator.exec(input);
    if (!match || match[0].length !== input.length) {
        console.log('Invalid message format');
        return;
    }
    let message_rows = match[3].split('\n');

    let attribute_validator = new RegExp(/^(?=.*?to="[\s\w\.]+")(?=.*?from="[\s\w\.]+")([a-z]+="[\s\w\.]+"\s*)+/, 'g');
    match = attribute_validator.exec(match[1]);
    if (!match) {
        console.log('Missing attributes');
        return;
    }
    let [to, from] = getAttr(match[0]);
    let html = generateHTML(to, from, message_rows);
    console.log(html);

    function getAttr(str) {

        let to = str.match(/\bto="([\s\w.]+)"/);
        let from = str.match(/\bfrom="([\s\w.]+)"/);
        return [to[1], from[1]];
    }

    function generateHTML(to, from, message_rows) {
        let html =
            '<article>\n' +
            `\t<div>From: <span class="sender">${from}</span></div>\n` +
            `\t<div>To: <span class="recipient">${to}</span></div>\n` +
            `\t<div>\n`;
        for (let row of message_rows) {
            html += `\t\t<p>${row}</p>\n`
        }
        html += '\t</div>\n</article>';
        return html;
    }
}

xmlMessenger('<message mailto="everyone" from="Grandma" to="Everyone">FWD: FWD: FWD: FWD: Forwards from grandma</message>');
