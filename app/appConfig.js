app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/",
        {
            templateUrl: "/app/views/home.html",
            controller: "homeController"
        })
        .when("/login",
        {
            templateUrl: "/app/views/login.html",
            controller: "loginController"
        });
}]);


app.run(["$rootScope", "$http", "$location", function ($rootScope, $http, $location) {

    $rootScope.isLoggedIn = function () { return !!sessionStorage.getItem("token") }

    $rootScope.$on("$routeChangeStart", function (event, currRoute) {
        var anonymousPage = false;
        var originalPath = currRoute.originalPath;

        if (originalPath) {
            anonymousPage = originalPath.indexOf("/login") !== -1;
        }

        if (!anonymousPage && !$rootScope.isLoggedIn()) {
            event.preventDefault();
            $location.path("/login");
        }
    });

    var token = sessionStorage.getItem("token");

    if (token)
        $http.defaults.headers.common["Authorization"] = `bearer ${token}`;
}])