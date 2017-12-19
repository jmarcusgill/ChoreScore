app.controller("addRewardController", ["$scope", "$http", "$location", function ($scope, $http, $location) {
    $scope.newReward = {
        isRedeemed: false

    };

    $scope.createReward = function () {
        console.log("inside createReward")
        $http.post("api/rewards/add",
            {
                RewardTitle: $scope.newReward.RewardTitle,
                Description: $scope.newReward.Description,
                isRedeemed: $scope.newReward.isRedeemed,
                PointValue: $scope.newReward.PointValue
            })
            .then(function (result) {
                console.log(result);
                $location.url("/Rewards");
            })
            .catch(error => console.log(error));
    }


}]);