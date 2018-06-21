const http = require('http');
const fs = require('fs');
const url = require('url');
const port = 5000;

const server = http.createServer(frontController);


function sendHtml(filePath, res, status=200, mime='text/html'){
    fs.readFile(filePath, 'utf8', (err, data) => {
        res.writeHead(status, {'content-type': mime});
        res.write(data);
        res.end();
    });
}

function sendCss(filePath, res, status=200, mime='text/css'){
    sendHtml(filePath,res,status,mime);
}


/**
 * @param {ClientRequest} req
 * @param {ServerResponse} res
 */
function frontController(req, res) {

    const path = url.parse(req.url).pathname;
    switch (path) {
        case '/':
        case '/index.html':
            sendHtml('./index.html',res);
            break;
        case '/about.html':
            sendHtml('./about.html',res);
            break;
        case '/style.css':
            sendCss('./style.css',res);
            break;
        default:
            sendHtml('./404.html',res,404);
            break;
    }
}

server.listen(port);
console.log(`Listening on port ${port} ...`);