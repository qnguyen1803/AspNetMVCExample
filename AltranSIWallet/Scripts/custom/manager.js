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

app.controller('managerCreateController', ($scope, $http) => {
    $scope.requiredMess = "Champs obligatoire";
    $scope.resetForm = () => {
        $scope.formObj = {
            UserAddDto: {
                FirstName: null,
                LastName: null,
                Username: null,
                Email: null,
                Password: null,
                Salary: null,
                EntryDate: null
            }
        }
    };

    $scope.resetForm();
    $scope.save = (form) => {
        if (!form.$valid) {
            toastr.error('Form invalid !!! ');
            return;
        }

        $scope.isloading = true;
        $http.post('/api/Managers/Create', $scope.formObj)
            .then(
                success => {
                    toastr.success("Saved!");
                    $scope.resetForm();
                },
                err => {
                    toastr.error("Une erreur s'est produite !");
                    throw new Error(err.data);
                }
            )
            .finally(() => {
                $scope.isloading = false;
            });
    } 
});

app.controller('managerEditController', ($scope, $http, $location, $q) => {
    $scope.requiredMess = "Champs obligatoire";
    let id = $location.absUrl().split("/").pop();
    if (id.includes("Details?id="))
        id = id.replace('Details?id=', '');

    $scope.resetForm = () => {
        $scope.formObj = {
            ConsultantsId: [],
            Id: id,
            User: {
                Id: 0,
                FirstName: null,
                LastName: null,
                Username: null,
                Email: null,
                Password: null,
                Salary: null,
                EntryDate: null
            }
        }
    };

    $scope.loadData = () => {
        $scope.isloading = true;
        $scope.consultants = [];
        let reqGetManagerById = $http.get(Config.apiUrl + "/api/Managers/GetById/" + id);
        let reqGetAllConsultants = $http.get(Config.apiUrl + "/api/Consultants/GetAll");
        $q.all([reqGetManagerById, reqGetAllConsultants])
            .then(
            ([res1, res2]) => {
                $scope.consultants = res2.data;
                $scope.manager = res1.data;
                $scope.manager.User.EntryDate = new Date($scope.manager.User.EntryDate);
                let consultantsId = [];
                $scope.manager.Consultants.map(item => {
                    item.Level = item.Level.Value;
                    consultantsId.push(item.Id);
                });
                
                if ($scope.manager) {
                    $scope.formObj = {
                        Id: id,
                        ConsultantsId: consultantsId,
                        User: $scope.manager.User
                    };

                    console.log($scope.formObj);
                }
            }, (err) => {
                toastr.error("Une erreur s'est produite !");
                throw new Error(err.data);
            }).finally(() => {
                $scope.isloading = false;
            });
    }

    $scope.resetForm();
    $scope.loadData();
    $scope.save = (form) => {
        if (!form.$valid) {
            toastr.error('Form invalid !!! ');
            return;
        }

        $scope.isloading = true;
        $http.post('/api/Managers/Update', $scope.formObj)
            .then(
                success => {
                    toastr.success('Saved!');
                    $scope.loadData();
                },
                err => {
                    toastr.error("Une erreur s'est produite !");
                    throw new Error(err.data);
                }
            )
            .finally(() => {
                $scope.isloading = false;
            });
    } 

});

