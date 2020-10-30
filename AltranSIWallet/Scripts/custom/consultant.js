app.controller('consultantListController', ($scope, $http) => {
    $scope.isloading = true;
    $http.get(Config.apiUrl + "/api/Consultants/GetAll")
        .then(
            (response) => {
                $scope.consultants = response.data;
            }, (err) => {
                toastr.error("Une erreur s'est produite !");
                throw new Error(err.data);
            })
        .finally(() => {
            $scope.isloading = false;
        });
});

app.controller('consultantDetailController', ($scope, $http, $location, $window) => {
    let id = $location.absUrl().split("/").pop();
    if (id.includes("Details?id="))
        id = id.replace('Details?id=', '');
    $scope.isloading = true;
    $http.get(Config.apiUrl + "/api/Consultants/GetById/" + id)
        .then(
            (response) => {
                $scope.consultant = response.data;
            }, (response) => {
                toastr.error("Une erreur s'est produite !");
                throw new Error(response.data);
            })
        .finally(() => {
            $scope.isloading = false;
        });

    $scope.remove = () => {
        $scope.isloading = true;
        $http.delete(Config.apiUrl + "/api/Consultants/Delete", { params: { id: id } })
            .then(
                res => {
                    $window.location.href = '/ConsultantView';
                }, err => {
                    toastr.error("Une erreur s'est produite !");
                    throw new Error(response.data);
                })
            .finally(() => {
                $scope.isloading = false;
            });
    }
});

app.controller('consultantCreateController', ($scope, $http, $location) => {
    $scope.requiredMess = "Champs obligatoire";
    $scope.ELevels = enumToArray(ELevels, "ELevels");
    $scope.managers = [];
    $scope.resetForm = () => {
        $scope.formObj = {
            Level: ELevels.Junior,
            SkillsFile: null,
            ProjectId: null,
            ManagerId: null,
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
    $scope.isloading = true;
    $http.get(Config.apiUrl + "/api/Managers/GetAll/").then(
        res => {
            $scope.managers = res.data;
        },
        err => {
            toastr.error("Une erreur s'est produite !");
            throw new Error(response.data);
        }
    ).finally(() => {
        $scope.isloading = false;
    });

    $scope.save = (form) => {
        if (!form.$valid) {
            toastr.error('Form invalid !!! ');
            return;
        }

        $scope.isloading = true;
        $http.post('/api/Consultants/Create', $scope.formObj)
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

app.controller('consultantEditController', ($scope, $http, $location, $q) => {
    let id = $location.absUrl().split("/").pop();
    if (id.includes("Edit?id="))
        id = id.replace('Edit?id=', '');
    $scope.requiredMess = "Champs obligatoire";
    $scope.ELevels = enumToArray(ELevels, "ELevels");
    $scope.managers = [];
    $scope.resetForm = () => {
        $scope.formObj = {
            Id: id,
            Level: ELevels.Junior,
            SkillsFile: null,
            ProjectId: null,
            ManagerId: null,
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
        let reqGetConsultantById = $http.get(Config.apiUrl + "/api/Consultants/GetById/" + id);
        let reqGetAllManagers = $http.get(Config.apiUrl + "/api/Managers/GetAll/");
        $scope.isloading = true;
        $q.all([reqGetConsultantById, reqGetAllManagers])
            .then(
                ([res1, res2]) => {
                    $scope.consultant = res1.data;
                    $scope.managers = res2.data;
                    $scope.consultant.User.EntryDate = new Date($scope.consultant.User.EntryDate);
                    $scope.formObj = {
                        Id: id,
                        Level: $scope.consultant.Level.Value,
                        SkillsFile: $scope.consultant.SkillsFile,
                        ProjectId: $scope.consultant.Project ? $scope.consultant.Project.Id : null,
                        ManagerId: $scope.consultant.Manager ? $scope.consultant.Manager.Id : null,
                        User: $scope.consultant.User
                    };
                }, (response) => {
                    toastr.error("Une erreur s'est produite !");
                    throw new Error(response.data);
                })
            .finally(() => {
                $scope.isloading = false;
            });
    };

    $scope.resetForm();
    $scope.loadData();

    $scope.save = (form) => {
        if (!form.$valid) {
            toastr.error('Form invalid !!! ');
            return;
        } 

        $scope.isloading = true;
        $http.post('/api/Consultants/Update', $scope.formObj)
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


