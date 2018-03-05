function getArticleGenerator(articles){


    return function (){
        if(articles.length===0) return;
        let article = articles.shift();
        $("#content").append($("<article>").text(article))
    }
}