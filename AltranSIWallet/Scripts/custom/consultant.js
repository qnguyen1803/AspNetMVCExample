app.controller('consultantController', function ($scope, $http) {
    console.log(Config.apiUrl);
    $http.get(Config.apiUrl + "/api/Consultants/GetAll")
    .then((response) => {
        $scope.consultants = response.data;
        console.log($scope.list);
    });
});