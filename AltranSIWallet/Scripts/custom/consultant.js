app.controller('consultantListController', function ($scope, $http) {
    $scope.isLoading = true;
    $http.get(Config.apiUrl + "/api/Consultants/GetAll")
        .then(
            successCallback(response) => {
                $scope.consultants = response.data;
            }, errorCallback(response) => {
                throw new Error(response.data);
        });
});

app.controller('consultantDetailController', function ($scope, $http, $location) {
    let id = $location.absUrl().split("/").pop();
    $http.get(Config.apiUrl + "/api/Consultants/GetById/" + id)
        .then(
            function successCallback(response) {
                $scope.consultant = response.data;
                console.log($scope.consultant);
            }, function errorCallback(response) {
                throw new Error(response.data);
            }
    );
});

app.controller('consultantCreateController', function ($scope, $http, $location) {

});

app.controller('consultantEditController', function ($scope, $http, $location) {
    let id = $location.absUrl().split("/").pop();
    $http.get(Config.apiUrl + "/api/Consultants/GetById/" + id)
        .then(
            function successCallback(response) {
                $scope.consultant = response.data;
                console.log($scope.consultant);
            }, function errorCallback(response) {
                throw new Error(response.data);
            }
        );
});
