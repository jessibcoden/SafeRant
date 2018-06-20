app.controller("HomeController", ["$scope", "$http", "$location", "$routeParams", "RantsService",
    function ($scope, $http, $location, $routeParams, RantsService) {

        $scope.message = "this is a test";

        $http.get("/api/rants").then(function (result) {
            $scope.rants = result.data;
        });

        $scope.navigateToAddRant = function () {
            $location.url(`AddRant`);
        };

        $scope.rantDetailView = function (Id) {
            $location.path(`/Rants/Detail/${Id}`);
        }
     
        $scope.rantDetail = {};

    }
]);