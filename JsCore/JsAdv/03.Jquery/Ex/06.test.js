document.body.innerHTML = '<div id="root"></div>';
result('#root', true);
var $root = $('#root');
var $addControls = $root.find('.add-controls');
var $tbAdd = $addControls.find('input');
var $btnAdd = $addControls.find('.button');
var clickEvent = document.createEvent('MouseEvents');

clickEvent.initMouseEvent('click', true, true,
    document.defaultView, 1, 0, 0, 0, 0, false,
    false, false, false, 1, null);
var count = 10,
    values = ['Test A', 'A Test'],
    value;

while (values.length < count) {
    value = 'NEW ' + Math.random();
    values.push(value);
}

for (var i = 0; i < count; i += 1) {
    value = values[i];
    $tbAdd.val(value);
    $btnAdd.get(0).dispatchEvent(clickEvent);
}

var $searchControls = $root.find('.search-controls');
var $tbSearch = $searchControls.find('input');
expect($tbSearch).to.has.length(1);

var $listItems = $root.find('.result-controls .items-list .list-item');
var pattern = 'a';

$tbSearch.val(pattern);

var inputEvent = document.createEvent('MouseEvents');
inputEvent.initUIEvent('input', true, true,
    document.defaultView, 1, 0, 0, 0, 0, false,
    false, false, false, 1, null);

var changeEvent = document.createEvent('MouseEvents');
changeEvent.initUIEvent('change', true, true,
    document.defaultView, 1, 0, 0, 0, 0, false,
    false, false, false, 1, null);

$tbSearch.get(0).dispatchEvent(inputEvent);
$tbSearch.get(0).dispatchEvent(changeEvent);

var expectedLength = values.filter(function (val) {
    return val.indexOf(pattern) >= 0;
}).length;
var actualLength = 0;

$listItems.each(function (index, listItem) {
    var $listItem = $(listItem);
    var innerHTML = $listItem.text();
    var indexOf = innerHTML.indexOf(pattern);
    var isFound = indexOf >= 0;
    if (isFound) {
        actualLength += 1;
        expect($listItem.css('display')).not.to.equal('none');
    } else {
        expect($listItem.css('display')).to.equal('none');
    }
});

expect(actualLength).to.equal(expectedLength);