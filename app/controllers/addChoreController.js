app.controller("addChoreController", ["$scope", "$http", "$location", function ($scope, $http, $location ) {
    $scope.newChore = {
        CompletedDate: null,
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