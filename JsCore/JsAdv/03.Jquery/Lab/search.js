function search() {

    let searchTerm = $('#searchText').val();
    let matches = 0;
    $('li').each(function () {
        if ($(this).text().includes(searchTerm)) {
            $(this).css('font-weight', 'bold');
            matches++
        }
    });

    $('#result').text(`${matches} matches found.`)


}