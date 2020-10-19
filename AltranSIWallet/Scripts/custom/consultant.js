console.log(ELevels);
app.controller('consultantListController', ($scope, $http) => {
    $scope.isloading = true;
    $http.get(Config.apiUrl + "/api/Consultants/GetAll")
        .then(
            (response) => {
                $scope.consultants = response.data;
            }, (err) => {
                throw new Error(err.data);
        })
        .finally(() => {
            $scope.isloading = false;
        });
});

app.controller('consultantDetailController', ($scope, $http, $location) => {
    $scope.isloading = true;
    let id = $location.absUrl().split("/").pop();
    $http.get(Config.apiUrl + "/api/Consultants/GetById/" + id)
        .then(
            (response) => {
                $scope.consultant = response.data;
            }, (response) => {
                throw new Error(response.data);
        })
        .finally(() => {
            $scope.isloading = false;
        });
});

app.controller('consultantCreateController', ($scope, $http, $location) => {
    $scope.isloading = true;
});

app.controller('consultantEditController', ($scope, $http, $location) => {
    $scope.ELevels = enumToArray(ELevels, "ELevels");
    $scope.level = ELevels.Junior;
    $scope.isloading = true;
    let id = $location.absUrl().split("/").pop();
    $http.get(Config.apiUrl + "/api/Consultants/GetById/" + id)
        .then(
            (response) => {
                $scope.consultant = response.data;
                $scope.level = response.data.Level.Value;
            }, (response) => {
                throw new Error(response.data);
            })
        .finally(() => {
            $scope.isloading = false;
        });
});
