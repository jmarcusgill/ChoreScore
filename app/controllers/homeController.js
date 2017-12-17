app.controller("homeController", ["$scope", "$http", function ($scope, $http) {
    $scope.chores = [];

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
    
    

}]);