function createBook(selector, title, author, isbn){



    (function bookGenerator(){
        let id = 1;
        let select = function(){
            $(this).parent('div').css('border' ,'2px solid blue');
        };
        let deselect = function(){
            $(this).parent('div').css('border','none');
        };
        return function(selector, title,author,isbn){

            $(selector)
                .append($('<div>',{id:`book${id}`})
                    .append($('<p>',{class:"title"}).text(title))
                    .append($('<p>',{class:'author'}).text(author))
                    .append($('<p>',{class:'isbn'}).text(isbn))
                    .append($('<button>').text('Select').click(select))
                    .append($('<button>').text('Deselect').click(deselect)));



        }
    })()(selector,title,author,isbn);
}