var FollowService = function() {

    var apiUrl = "/api/following/";

    var createFollow = function(followeeId, done, fail) {
        $.post(apiUrl, { followeeId: followeeId })
            .done(done).fail(fail);
    };

    var deleteFollow = function(followeeId, done, fail) {
        $.ajax({
            url: apiUrl + followeeId,
            method: "DELETE"
        }).done(done).fail(fail);

    };

    return {
        createFollow: createFollow,
        deleteFollow: deleteFollow
    }

}();