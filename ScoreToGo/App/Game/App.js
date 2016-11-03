appMainModule.controller("gameViewModel", function ($scope, $http, $location, $window) {
    $scope.init = function (gamePlay) {
        $scope.gamePlay = gamePlay;
    }

    $scope.headingCaption = "Game";
    
    $scope.addPoint = function (pointWinner) {
        var Indata = { gameModel: $scope.gamePlay, pointWinner: pointWinner }
        $http.post("/Game/AddPoint", Indata).success(function (data) {
            $scope.gamePlay = data;
            if ($scope.gamePlay.GameOver === true) //!! need angular routes to pass this data to the GameOver page
            {
                $window.location.href = "Game/GameOver";
            }
        })
        .error(function (error, status){
            $scope.data.error = { message: error, status: status};
            console.log($scope.data.error.status); })
    }
});