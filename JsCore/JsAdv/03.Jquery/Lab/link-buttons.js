function attachEvents(){

    let selected;
    $('a').on('click',function (){
        if(selected){
            selected.removeClass('selected');
        }

        selected = $(this);
        $(this).addClass('selected');
    })
}