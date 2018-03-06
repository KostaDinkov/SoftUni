let expect = require('chai').expect;
let jsdom = require('jsdom-global')();
$ = require("jquery");

let nuke = require('./06.Armagedom').nuke;

document.body.innerHTML = `<div id="target">
    <div class="nested target">
        <p>This is some text</p>
    </div>
    <div class="target">
        <p>Empty div</p>
    </div>
    <div class="inside">
        <span class="nested">Some more text</span>
        <span class="target">Some more text</span>
    </div>
</div>
`;

