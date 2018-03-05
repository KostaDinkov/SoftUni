function attachEvents(){


    $('#items').on('click','li',toggleSelected);

    function toggleSelected(event){
        let el = $(this);
        if(el.attr('data-selected')){

            el.removeAttr('data-selected');
            el.css('background',"")
        }
        else{
            el.attr('data-selected','true');
            el.css('background','#DDD')

        }

    }
    $("#showTownsButton").on('click',function(){
        $("#selectedTowns").text("Selected towns: " + $('#items').find('li[data-selected]').toArray().map(e=>$(e).text()).join(", "));
    });


}