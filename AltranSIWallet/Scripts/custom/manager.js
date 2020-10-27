app.controller('managerListController', ($scope, $http) => {
    $http.get(Config.apiUrl + "/api/Managers/GetAll")
        .then(
            function successCallback(response) {
                $scope.managers = response.data;
            }, function errorCallback(response) {
                toastr.error("Une erreur s'est produite !");
                throw new Error(response.data);
            }
        );
});

app.controller('managerDetailController', ($scope, $http, $location) => {
    let id = $location.absUrl().split("/").pop();
    if (id.includes("Details?id="))
        id = id.replace('Details?id=', '');
    $scope.isloading = true;
    $http.get(Config.apiUrl + "/api/Managers/GetById/" + id)
        .then(
            (response) => {
                $scope.manager = response.data;
            }, (response) => {
                toastr.error("Une erreur s'est produite !");
                throw new Error(response.data);
            })
        .finally(() => {
            $scope.isloading = false;
        });

    $scope.remove = () => {
        $scope.isloading = true;
        $http.delete(Config.apiUrl + "/api/Managers/Delete", { params: { id: id } })
            .then(
                res => {
                    $window.location.href = '/ManagerView';
                }, err => {
                    toastr.error("Une erreur s'est produite !");
                    throw new Error(response.data);
                })
            .finally(() => {
                $scope.isloading = false;
            });
    }
});

app.controller('managerEditController', ($scope, $http) => {
    let id = $location.absUrl().split("/").pop();
    if (id.includes("Details?id="))
        id = id.replace('Details?id=', '');
    $scope.isloading = true;
});

app.controller('managerEditController', ($scope, $http) => {
    let id = $location.absUrl().split("/").pop();
    if (id.includes("Details?id="))
        id = id.replace('Details?id=', '');
    $scope.isloading = true;
    $http.get(Config.apiUrl + "/api/Managers/GetById/" + id)
        .then(
            (response) => {
                $scope.manager = response.data;
            }, (response) => {
                toastr.error("Une erreur s'est produite !");
                throw new Error(response.data);
            })
        .finally(() => {
            $scope.isloading = false;
        });
});