appMainModule.controller("gameViewModel", function ($scope, $http, $location, $window) {
    $scope.init = function (gamePlay) {
        $scope.gamePlay = gamePlay;
    }

    $scope.teamsData = {
        teamACanScore: true,
        teamBCanScore: true
    };
   
    $scope.addPoint = function (pointWinner) {
        var Indata = { gameModel: $scope.gamePlay, pointWinner: pointWinner }
        $http.post("/Game/AddPoint", Indata).success(function (data) {
            $scope.gamePlay = data;
            if ($scope.gamePlay.GameOver === true) {
                $window.location.href = "/game-stats/" + $scope.gamePlay.GameId;
            }
        })
        .error(function (error, status) {
            logError(error, status)//!! proper error logging for JS
        })
    }

    //Substituitions
    $scope.showSubstitutionPanel = false;
    $scope.substitutionData = {
        substitutionTeam: -1,
        shirtNumberComingOut: 0,
        shirtNumberGoingIn: 0
    };


    $scope.openSubstitutionPanel = function (team, shirtNumberComingOut) {
        $scope.showSubstitutionPanel = true;
        $scope.substitutionData.substitutionTeam = team;
        $scope.substitutionData.shirtNumberComingOut = shirtNumberComingOut;
    }
    $scope.substitute = function () {
        var Indata = { gameModel: $scope.gamePlay, team: $scope.substitutionData.substitutionTeam, shirtNumberGoingIn: $scope.substitutionData.shirtNumberGoingIn, shirtNumberComingOut: $scope.substitutionData.shirtNumberComingOut }
        $http.post("/Game/Substitute", Indata).success(function (data) {
            $scope.gamePlay = data;
            $scope.showSubstitutionPanel = false;
            $scope.substitutionData.substitutionTeam = -1;
            $scope.substitutionData.shirtNumberComingOut = 0;
            $scope.substitutionData.shirtNumberGoingIn = 0;
        })
        .error(function (error, status) {
            $scope.data.error = { message: error, status: status };
            console.log($scope.data.error.status);
        })
    }

    //Time outs
    $scope.showTimeOutPanel = false;
    $scope.timeOutData = {
        teamAHasAvailableTimeOuts: true,
        teamBHasAvailableTimeOuts: true
    };

    $scope.startTimeOut = function (team) {
        $scope.teamsData.teamACanScore = false;
        $scope.teamsData.teamBCanScore = false;
        $scope.showTimeOutPanel = true;
        $scope.$broadcast('timer-reset');
        $scope.$broadcast('timer-start');
        var Indata = { gameModel: $scope.gamePlay, team: team }
        $http.post("/Game/LogTimeOut", Indata).success(function (data) {
            $scope.gamePlay = data;
            if ($scope.gamePlay.GameUpdateResult === 1) {
                if (team === 0) {
                    $scope.timeOutData.teamAHasAvailableTimeOuts = false;
                }
                else {
                    $scope.timeOutData.teamBHasAvailableTimeOuts = false;
                }
            }
        })
        .error(function (error, status) {
            $scope.data.error = { message: error, status: status };
            console.log($scope.data.error.status);
        })
    }

    $scope.endTimeOut = function () {
        $scope.teamsData.teamACanScore = true;
        $scope.teamsData.teamBCanScore = true;
        $scope.showTimeOutPanel = false;
    }

    $scope.$on('timer-stopped', function (event, data) {
        $scope.$apply(function () {
            $scope.endTimeOut();
        });
    });

    function logError(error, status) {
        $scope.data.error = { message: error, status: status }; //!! proper error logging for JS
        console.log($scope.data.error.status);
    };
});