var app = angular.module("SafeRant", ["ngRoute", "ui.bootstrap"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.when("/",
    {
        templateUrl: "/app/partials/Home.html",
        controller: "HomeController"
        })

        .when("/AddRant",
        {
            templateUrl: "/app/partials/addRant.html",
            controller: "AddRantController"
        })

        .when("/Rants/Detail/:Id",
        {
            templateUrl: "/app/partials/RantDetail.html",
            controller: "RantDetailController"
        })
}]);