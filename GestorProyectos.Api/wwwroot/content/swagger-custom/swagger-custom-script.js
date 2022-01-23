(function () {
    window.addEventListener("load", function () {
        setTimeout(function () {
            var logo = document.getElementsByClassName('link');
            //logo[0].href = "/";
            //logo[0].target = "_blank";

            logo[0].children[0].alt = "API";
            logo[0].children[0].height = "80";
            logo[0].children[0].src = "../content/img/logo.png";
        });
    });
})();