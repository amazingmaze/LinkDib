var LikeService = function() {

    var apiUrl = "/api/likes/";

    var createLike = function(linkId, done, fail) {
        $.post(apiUrl, { linkId: linkId })
            .done(done).fail(fail);

    };

    var deleteLike = function(linkId, done, fail) {
        $.ajax({
            url: apiUrl + linkId,
            method: "DELETE"
        }).done(done).fail(fail);

    };

    return {
        createLike: createLike,
        deleteLike: deleteLike
    }



}();