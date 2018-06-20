app.controller("RantDetailController", ["$scope", "$http", "$location", "$routeParams", "RantsService",
    function ($scope, $http, $location, $routeParams, RantsService) {

        $http.get("/api/categories").then(function (result) {
            $scope.categories = result.data;
        });

        const getRant = () => {
            console.log("in da controller")
            RantsService.getRantById($routeParams.Id).then((results) => {
                //results.data.PurchaseDate = new Date(results.data.PurchaseDate);
                $scope.rant = results.data;
            });
        };

        getRant();

        $scope.formInputRequired = true;


        $scope.UpdateRantAndClose = function () {
            RantsService.updateRantDetails($scope.rant).then(function (results) {
                $location.url(`/`);
            }).catch(function (err) {
                console.log("error in addRant in view controller");
            })
        }

        $scope.navigateToList = function () {
            $scope.formInputRequired = false;
            $location.url(`/`);
        };

        $scope.deleteRant = function (rantId) {
            RantsService.deleteRant(rantId).then(function (results) {
                $location.url(`/`);
            }).catch(function (err) {
                console.log("error in deleteRant in Controller", err);
            });
        };
    }
]);

