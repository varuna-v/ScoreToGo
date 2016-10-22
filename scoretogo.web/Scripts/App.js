var appMainModule = angular.module('appMain', []);

appMainModule.controller("homePageViewModel", function ($scope, $http, $location) {
    $scope.headingCaption = "This is the home page"; 

    $scope.theSet = { FirstServer: '1', Winner: '0' };

    $scope.showSet = function (set) { 
        alert('First server ' + set.FirstServer + ' Winner ' + set.Winner);
    }
});