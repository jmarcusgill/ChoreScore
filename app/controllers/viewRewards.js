app.controller("viewRewardController", ["$scope", "$http", function ($scope, $http) {
    $scope.rewards = [];

    var getRewards = function () {
        $http.get("api/Rewards")
            .then(function (result) {
                var dataResults = result.data;
                var listOfRewards = [];

                if (dataResults.length > 0) {
                    Object.keys(dataResults).forEach((key) => {
                        dataResults[key].id = key;
                        listOfRewards.push(dataResults[key]);
                    });
                }
                $scope.rewards = listOfRewards;
                console.log($scope.rewards);
            }).catch(function (error) {
                console.log(error);
            });
    };

    getRewards();




}]);