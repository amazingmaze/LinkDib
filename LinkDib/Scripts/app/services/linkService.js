var LinkService = function() {

    var apiUrl = "/api/link/";

    var deleteLink = function(linkId, done, fail) {
        $.ajax({
            url: apiUrl + linkId,
            method: "DELETE"
        }).done(done).fail(fail);

    };

    return {
        deleteLink: deleteLink
    }

}();