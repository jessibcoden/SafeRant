app.controller("AddRantController", ["$scope", "$http", "$location", "RantsService",
    function ($scope, $http, $location, RantsService) {

        $http.get("/api/categories").then(function (result) {
            $scope.categories = result.data;
        });

        $scope.formInputRequired = true;

        $scope.newRant = {};

        $scope.addRantAndClose = function () {
            RantsService.addRant($scope.newRant).then(function (results) {
                $location.url(`/`);
            }).catch(function (err) {
                console.log("error in addRant in view controller");
            })
        }

        $scope.navigateToList = function () {
            console.log("WTF");
            $scope.formInputRequired = false;
            $location.url(`/`);
        };

        $scope.rantDetailView = function (rantId) {
            $location.path(`/Rants/Detail.${Id}`);
        }

        $scope.rantDetail = {};

    }
]);

