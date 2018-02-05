function extractLinks(strings_arr){

    let re = RegExp(/www\.[a-zA-Z0-9\-]+(\.[a-z]+)+/,'g');
    for (let string of strings_arr) {
        let matches = string.match(re);
        if(matches){
            console.log(matches.join('\n'))
        }

    }

}

extractLinks(["Join WebStars now for free, at www.web-stars.com\n",
    "You can also support our partners:\n",
    "Internet - www.internet.com\n",
    "WebSpiders - www.webspiders101.com\n",
    "Sentinel - www.sentinel.-ko \n"]);