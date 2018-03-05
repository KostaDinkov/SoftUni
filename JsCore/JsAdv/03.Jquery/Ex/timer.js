function timer(){

    let hours = $('#hours');
    let minutes = $("#minutes");
    let seconds = $('#seconds');
    let totalSeconds = 1;
    let timer;

    $('#start-timer').on('click',function(){

        //update();
        window.clearInterval(timer);
        timer = window.setInterval(update,1000);
    });

    $('#stop-timer').on('click',function(){
        if(timer){
            window.clearInterval(timer);
            timer = null;
        }
        // else{
        //
        //     timer = window.setInterval(update,1000)
        // }
    });



    function update(){

        let hh = leadingZero(Math.floor(totalSeconds/3600));
        let reminder = totalSeconds % 3600;
        let mm = leadingZero(Math.floor(reminder/60));
        let sec = leadingZero(reminder % 60);
        totalSeconds+=1;
        hours.text(hh);
        minutes.text(mm);
        seconds.text(sec);
    }

    function leadingZero(time){
        return time.toString().length<2?"0"+time:time;
    }
}