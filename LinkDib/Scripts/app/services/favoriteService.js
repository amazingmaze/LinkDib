var FavoriteService = function () {

    var apiUrl = "/api/favorites/";

    var createFavorite = function (linkId, done, fail) {
        $.post(apiUrl, { linkId: linkId })
            .done(done).fail(fail);
    };

    var deleteFavorite = function (linkId, done, fail) {
        $.ajax({
            url: apiUrl + linkId,
            method: "DELETE"
        }).done(done).fail(fail);

    };

    return {
        createFavorite: createFavorite,
        deleteFavorite: deleteFavorite
    }
}();