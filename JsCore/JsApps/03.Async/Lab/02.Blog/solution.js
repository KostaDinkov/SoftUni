function attachEvents() {
    /*********************************************
     * Set up and element bindings
     *********************************************/
        //kinvey setup
    let username = 'user';
    let password = 'user';
    let baseUrl = 'https://baas.kinvey.com/appdata/kid_rywhJjQ5M/';

    //bind thml elements
    let $postsSelect = $('#posts');
    let $postTitle = $('#post-title');
    let $postBody = $('#post-body');
    let $commentsList = $('#post-comments');

    //bind buttons
    $('#btnLoadPosts').on('click', loadPosts);
    $('#btnViewPost').on('click', viewPost);

    //create a local posts Map to reduce network
    //requests to the posts collection
    let posts;

    /*************************************************
     *  Functionality
     *************************************************/

    function loadPosts() {
        let postsUrl = baseUrl + 'posts/';
        $.ajax({
            url: postsUrl,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Basic " + btoa(username + ":" + password));
            },
            method: 'GET',
        }).done(renderPosts);
    }

    function renderPosts(data) {
        posts = new Map();
        $postsSelect.empty();
        data.forEach((post) => {
            $postsSelect.append($(`<option value="${post._id}">${post.title}</option>`));

            posts.set(post._id, {title: post.title, body: post.body})
        });
        console.log($postsSelect.text());
    }

    function viewPost() {

        let id = $postsSelect.val();
        let selectedPost = posts.get(id);
        $postTitle.text(selectedPost.title);
        $postBody.text(selectedPost.body);

        //display comments
        let commentUrl = baseUrl + `comments/?query={"post_id":"${id}"}`;
        $.ajax({
            url: commentUrl,
            beforeSend: function (xhr) {
                xhr.setRequestHeader("Authorization", "Basic " + btoa(username + ":" + password));
            },
            method: 'GET',
        }).done(function (data) {
            $commentsList.empty();
            data.forEach((comment) => {

                $commentsList.append($(`<ul>${comment.text}</ul>`))
            });
        })
    }
}

//exports.attachEvents = attachEvents;