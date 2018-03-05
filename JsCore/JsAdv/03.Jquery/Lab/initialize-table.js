function initializeTable() {

    function up() {
        let row = ($(this).parents('tr'));
        row.insertBefore(row.prev());
        updateLinks();

    }
    function down() {
        let row = ($(this).parents('tr'));
        if(row.next()){
            row.insertAfter(row.next());
        }
        updateLinks();
    }
    function del(){
        let row = ($(this).parents('tr'));

        row.fadeOut(function (){row.remove()});
        updateLinks();
    }

    const rowTemplate = (country, capital) => `<tr><td>${country}</td><td>${capital}</td><td><a href="#" id="upBtn">[Up]</a><a href="#" id="downBtn">[Down]</a><a href="#" id="delBtn"">[Delete]</a></td></tr>`;

    $('#countriesTable')
        .append(rowTemplate("Bulgaria", "Sofia"))
        .append(rowTemplate("Germany", "Berlin"))
        .append(rowTemplate("Russia", "Moscow"))
        .on('click', '#upBtn', up)
        .on('click', '#downBtn', down)
        .on('click', '#delBtn',del);
    updateLinks();


    $('#createLink').on('click',insertRow);

    function insertRow(){
        let newCountry = $('#newCountryText');
        let newCapital = $('#newCapitalText');
        $('#countriesTable').append(rowTemplate(newCountry.val(), newCapital.val()));
        newCountry.val('');
        newCapital.val('');
        updateLinks();
    }

    function updateLinks(){
        let links = $('#countriesTable a');
        links.css('display','inline');

        let rows = $("#countriesTable tr");
        $(rows[2]).find('a:contains("Up")').css('display','none');

        $(rows[rows.length-1]).find('a:contains("Down")').css('display','none');


    }



}