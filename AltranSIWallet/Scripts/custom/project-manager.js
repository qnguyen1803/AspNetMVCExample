app.controller('projectManagerListController', function ($scope, $http) {
    $http.get(Config.apiUrl + "/api/ProjectManagers/GetAll")
        .then(
            function successCallback(response) {
                $scope.projectmanagers = response.data;
            }, function errorCallback(response) {
                throw new Error(response.data);
            }
        );
});