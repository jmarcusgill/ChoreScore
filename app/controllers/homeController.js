app.controller("homeController", ["$scope", "$http", function ($scope, $http) {
    $scope.chores = [];

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
            }).catch(function (error) {
                console.log(error)
            });
        
    }


    

    

    
    
    

}]);