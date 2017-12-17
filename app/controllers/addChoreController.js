app.controller("addChoreController", ["$scope", "$http", "$location", function ($scope, $http, $location ) {
    $scope.newChore = {
        CompletedDate: "2012 - 12 - 21T13: 13:58",
        isAssigned: false,
        PointsAssigned: 100

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
                $location.url("/");
            })
            .catch(error => console.log(error));
    }

}]);