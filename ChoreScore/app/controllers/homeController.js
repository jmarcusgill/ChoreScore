app.controller("homeController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    $scope.chores = [];
    $scope.points = [];
    $scope.isCompleted = true;
    $scope.newChore = {
        isAssigned: false,
    };


    var getChores = function () {
        $http.get("api/Chores")
            .then(function (result) {
                var dataResults = result.data;
                var listOfChores = [];

                if (dataResults.length > 0) {
                    Object.keys(dataResults).forEach((key) => {
                        dataResults[key].id = key;
                        listOfChores.push(dataResults[key]);
                    });
                }
                $scope.chores = listOfChores;
                console.log($scope.chores);
            }).catch(function (error) {
                console.log(error);
            });
    };

    getChores();

    var getUserPoints = function () {
        console.log("in getUserPoints")
        $http.get("api/Account/UserInfo")
            .then(function (result) {
                var dataResults = result.data;
                var listOfPoints = [];

                if (dataResults.length > 0) {
                    Object.keys(dataResults).forEach((key) => {
                        dataResults[key].id = key;
                        listOfPoints.push(dataResults[key]);
                    });
                }
                $scope.points = listOfPoints;
                console.log($scope.points);
            }).catch(function (error) {
                console.log(error);
            });
    };

    


    $scope.createChore = function () {
        console.log("inside createChore")
        $http.post("api/Chores/add",
            {
                ChoreName: $scope.newChore.ChoreName,
                StartDate: $scope.newChore.StartDate,
                PointsAssigned: $scope.newChore.PointsAssigned,
                isAssigned: $scope.newChore.isAssigned,
                CompletedDate: $scope.newChore.CompletedDate
            })
            .then(function (result) {
                console.log(result);
                getChores();
                $location.url("/");
            })
            .catch(error => console.log(error));
    }


    $scope.deleteChore = function (choreId) {
        console.log("deleteChore click", choreId)
        $http.delete(`api/Chores/${choreId}`)
            .then(function (result) {
                getChores();
            })
            .catch(function (error)
            {
                console.log(error);
            })
    }

    $scope.doChore = function (choreId) {
        console.log("doChore click", choreId);
        $http.put(`api/Chores/${choreId}/dochore`)
            .then(function (result) {
                console.log("result", result)
                getChores();
            }).catch(function (error) {
                console.log(error)
            });
        
    }

    


    

    

    
    $scope.clearForm = function () {
        document.getElementById("myForm").reset()
    }

}]);