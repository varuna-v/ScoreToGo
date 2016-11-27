var appMainModule = angular.module('main', ['ngMaterial', 'ngAnimate', 'ngAria', 'timer', 'ngRoute'])
         .config(function ($routeProvider, $locationProvider) {
             $routeProvider.when('/game', { templateUrl: '/App/Game/Views/gameplay.html', controller: 'gameViewModel' });
             $routeProvider.when('/game/gameover', { templateUrl: 'App/Game/Views/gameover.html', controller: 'gameViewModel' });
             $routeProvider.when('/game-stats/:gameId', { templateUrl: 'App/GameStats/Views/gamestats.html', controller: 'gameStatsViewModel' });
             $routeProvider.otherwise({ redirectTo: '/game' }); //!! make this go to a 404 page instead
             $locationProvider.html5Mode(true);
         });

