//IEFE
var LinksController = function (favoriteService, likeService, followService, linkService) {

    var init = function (container) {

        var favorite = function () {

            var favoriteIcon;

            var fail = function () {
                alert("Favorizing failed..");
            };

            var done = function () {
                favoriteIcon.toggleClass("favored").toggleClass("notfavored");
            };

            var toggleFavorite = function (e) {
                favoriteIcon = $(e.target);
                var linkId = favoriteIcon.attr("data-link-id");

                if (favoriteIcon.hasClass("notfavored"))
                    favoriteService.createFavorite(linkId, done, fail);
                else
                    favoriteService.deleteFavorite(linkId, done, fail);
            };

            $(container).on("click", ".js-toggle-favorite", toggleFavorite);
        }();


        var like = function() {

            var likeIcon;

            var done = function() {
                likeIcon.toggleClass("liked").toggleClass("notliked");
            };

            var fail = function() {
                alert("Liking failed");
            };

            var toggleLike = function (e) {
                likeIcon = $(e.target);
                var linkId = likeIcon.attr("data-link-id");

                if (likeIcon.hasClass("notliked")) {
                    likeService.createLike(linkId, done, fail);
                } else {
                    likeService.deleteLike(linkId, done, fail);
                }
            };

            $(container).on("click", ".js-toggle-like", toggleLike);
        }();


        var follow = function () {
            var followIcon;

            var done = function () {
                followIcon.toggleClass("btn-info").toggleClass("btn-default").text( (followIcon.text() == "Following") ? "Follow" : "Following");
            };

            var fail = function () {
                alert("Following failed.");
            };

            var toggleFollow = function (e) {
                followIcon = $(e.target);
                var followeeId = followIcon.attr("data-user-id");
                if (followIcon.hasClass("btn-default")) {
                    followService.createFollow(followeeId, done, fail);
                } else {
                    followService.deleteFollow(followeeId, done, fail);
                }
            };

            $(container).on("click", ".js-toggle-follow", toggleFollow);
        }();


        var link = function() {

            var linkObj;
            var done = function() {
                linkObj.parents("li").fadeOut(function() {
                    $(this).remove();
                });
            };

            var fail = function() {
                alert("Delete failed");
            };

            var cancelLink = function(e) {
                bootbox.confirm("Are you sure you want to delete this link?", function (result) {
                    linkObj = $(e.target);
                    var linkId = linkObj.attr("data-link-id");
                    if (!result) {
                        return;
                    } else {
                        linkService.deleteLink(linkId, done, fail);
                    }
                });
            };

            $(container).on("click", ".js-cancel-link", cancelLink);

        }();


    };

    return {
        init: init
    }
}(FavoriteService, LikeService, FollowService, LinkService);
