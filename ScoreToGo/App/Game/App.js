appMainModule.controller("gameViewModel", function ($scope, $http, $location, $window) {
    $scope.init = function (gamePlay) {
        $scope.gamePlay = gamePlay;
    }

    $scope.headingCaption = "Game";

    $scope.teamACanScore = true;
    $scope.teamBCanScore = true;

    $scope.addPoint = function (pointWinner) {
        var Indata = { gameModel: $scope.gamePlay, pointWinner: pointWinner }
        $http.post("/Game/AddPoint", Indata).success(function (data) {
            $scope.gamePlay = data;
            if ($scope.gamePlay.GameOver === true) //!! need angular routes to pass this data to the GameOver page
            {
                $window.location.href = "Game/GameOver";
            }
        })
        .error(function (error, status) {
            $scope.data.error = { message: error, status: status }; //!! proper error logging for JS
            console.log($scope.data.error.status);
        })
    }

    //Substituitions
    $scope.showSubstitutionPanel = false;
    $scope.substitutionTeam = -1;
    $scope.shirtNumberComingOut = 0;
    $scope.shirtNumberGoingIn = 0;

    $scope.openSubstitutionPanel = function (team, shirtNumberComingOut) {
        $scope.showSubstitutionPanel = true;
        $scope.substitutionTeam = team;
        $scope.shirtNumberComingOut = shirtNumberComingOut;
    }
    $scope.substitute = function () {
        var Indata = { gameModel: $scope.gamePlay, team: $scope.substitutionTeam, shirtNumberGoingIn: $scope.shirtNumberGoingIn, shirtNumberComingOut: $scope.shirtNumberComingOut }
        $http.post("/Game/Substitute", Indata).success(function (data) {
            $scope.gamePlay = data;
            $scope.showSubstitutionPanel = false;
            $scope.substitutionTeam = -1;
            $scope.shirtNumberComingOut = 0;
            $scope.shirtNumberGoingIn = 0;
        })
        .error(function (error, status) {
            $scope.data.error = { message: error, status: status };
            console.log($scope.data.error.status);
        })
    }

    //Time outs
    $scope.showTimeOutPanel = false;
    $scope.teamAHasAvailableTimeOuts = true;
    $scope.teamBHasAvailableTimeOuts = true;

    $scope.startTimeOut = function (team) {
        $scope.teamACanScore = false;
        $scope.teamBCanScore = false;
        $scope.showTimeOutPanel = true;
        $scope.$broadcast('timer-reset');
        $scope.$broadcast('timer-start');
        var Indata = { gameModel: $scope.gamePlay, team: team }
        $http.post("/Game/LogTimeOut", Indata).success(function (data) {
            $scope.gamePlay = data;
            if ($scope.gamePlay.GameUpdateResult === 1) {
                if (team === 0) {
                    $scope.teamAHasAvailableTimeOuts = false;
                }
                else {
                    $scope.teamBHasAvailableTimeOuts = false;
                }
            }
        })
        .error(function (error, status) {
            $scope.data.error = { message: error, status: status };
            console.log($scope.data.error.status);
        })
    }

    $scope.endTimeOut = function () {
        $scope.teamACanScore = true;
        $scope.teamBCanScore = true;
        $scope.showTimeOutPanel = false;
    }

    $scope.$on('timer-stopped', function (event, data) {
        $scope.$apply(function () {
            $scope.endTimeOut();
        });
    });
});