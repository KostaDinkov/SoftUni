function domSearch(selector, caseSensitive) {

    let $list = $('<ul></ul>', {'class': 'items-list'});
    let $enterInput = $('<input>');
    let $addBtn = $('<a>', {'class': 'button', 'style': 'display: inline-block'})
        .text("Add")
        .on('click', function () {
            addItem($enterInput, $list)
        });

    let $searchInput = $('<input>').on('input', function () {
        search($list, $searchInput.val(), caseSensitive);
    });

    $(selector)
        .append($('<div>', {'class': 'add-controls'})
            .append($('<label>').text('Enter text:')
                .append($enterInput))
            .append($addBtn))
        .append($('<div>', {'class': 'search-controls'})
            .append($('<label>').text('Search:')
                .append($searchInput)))
        .append($('<div>', {'class': 'result-controls'})
            .append($list));


    function search($list, term) {

        let elements = $list.children('li');
        elements.each((i, e) => {
            let text = $(e).find('strong').text();

            if (!caseSensitive || caseSensitive === undefined) {
                text = text.toLowerCase();
                term = term.toLowerCase();
            }

            if (text.indexOf(term) < 0) {
                $(e).css('display', 'none');
            }
            else {
                $(e).removeAttr('style');
            }
        })

    }

    function addItem($input, $list) {

        let $item = $('<li>', {'class': 'list-item'});
        let $delBtn = $('<a>', {"class": 'button'}).text('X').on('click', function () {
            $item.remove()
        });
        $list.append($item.append($delBtn).append($('<strong>').text($input.val())));
        $input.val('');

    }

}