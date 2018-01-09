app.controller("viewRewardController", ["$scope", "$http", function ($scope, $http) {
    $scope.rewards = [];

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
                getRewards();
                
            })
            .catch(error => console.log(error));
    }

    var getRewards = function () {
        $http.get("api/rewards")
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

    $scope.redeemReward = function (rewardId) {
        console.log("redeemReward click", rewardId);
        $http.put(`api/rewards/${rewardId}/redeem`)
            .then(function (result) {
                console.log("result of redeemRewards: ", result)
                getRewards();
            }).catch(function (error) {
                console.log(error)
            });

    }

    $scope.deleteReward = function (rewardId) {
        console.log("inside deleteReward id: ", rewardId)
        $http.delete(`api/rewards/${rewardId}`)
            .then(function (result) {
                getRewards();
            }).catch(function (error) {
                console.log(error)
            });
    }




}]);