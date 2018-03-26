let expect = require('chai').expect;
let result = require('./solution').attachEvents;


server.respondWith((request) => {
    if (request.method == 'GET') {
        expect(request.requestHeaders.Authorization).to.contains('Basic');
        let target = request.url.split('/');
        target = target[target.length - 1];
        expect(target).to.equal('posts');
        let response = `[{"_id":"582cde77209db9d9730bab03","title":"Post1","body":"Post #1 body"},{"_id":"582ce30adb630ca5056856d6","title":"Post2","body":"Post #2 body"}]`;
        request.respond(200, {"Content-Type": "application/json"}, response);
    } else {
        request.respond(500, {}, "");
    }
});

server.respondImmediately = true;
document.body.innerHTML = `<button id="btnLoadPosts">Load Posts</button>
<select id="posts"></select>
<button id="btnViewPost">View</button>

<h1 id="post-title">Post Details</h1>
<ul id="post-body"></ul>
<h2>Comments</h2>
<ul id="post-comments"></ul>`;

global['btoa'] = function (str) {
    return str;
};

result();
$("#btnLoadPosts").trigger('click');

setTimeout(nextStep, 20);

function nextStep() {
    let posts = $('#posts').text();
    expect(posts).to.contains('Post1');
    expect(posts).to.contains('Post2');
    done();
}