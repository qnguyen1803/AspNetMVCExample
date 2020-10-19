app.controller('managerListController', function ($scope, $http) {
    $http.get(Config.apiUrl + "/api/Managers/GetAll")
        .then(
            function successCallback(response) {
                $scope.managers = response.data;
                console.log($scope.managers);
            }, function errorCallback(response) {
                throw new Error(response.data);
            }
        );
});