appMainModule.controller("gameStatsViewModel", function ($scope, $http, $location, $window) {
    $scope.init = function (gameStats) {
        $scope.gameStats = gameStats;
    }
});