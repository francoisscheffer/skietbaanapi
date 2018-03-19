


var myApp = angular.module('skietbaanApp', ['ui.grid']);

myApp.controller('ScoreOverview', ["$scope", "$http", function ($scope, $http) {
    debugger;
  

        $scope.loadAllShootsForMonth = function () {

            var selectedC = 1;
            if ($scope.selectedCompetition != null)
                selectedC = $scope.selectedCompetition.pkid;


            $http({
                method: 'Get',
                url: '/api/ShootOverview',
                params: {
                    comp: selectedC,
                    currentyear: $scope.thisyear
                }
            }).success(function (data, status, headers, config) {

                $scope.gridData = data;

            }).error(function (data, status, headers, config) {
            });
        };

        $scope.loadAllShootsForYear = function () {

            var selectedC = 1;
            if ($scope.selectedCompetition != null)
                selectedC = $scope.selectedCompetition.pkid;


            $http({
                method: 'Get',
                url: '/api/ShootOverviewYearly',
                params: {
                    comp: selectedC,
                    currentyear: $scope.thisyear
                }
            }).success(function (data, status, headers, config) {
                debugger;
                $scope.gridData2 = data;

            }).error(function (data, status, headers, config) {
            });
        };

        $scope.loadCompetitions = function () {

            $http({
                method: 'Get',
                url: '/api/competitions'
                //params: { comp: selectedCompetition }
            }).success(function (data, status, headers, config) {
                $scope.Competitions = data;
                $scope.selectedCompetition = data[0];
            }).error(function (data, status, headers, config) {
            });
        }

        $scope.changecomp = function () {


            $scope.loadAllShootsForMonth();
            $scope.loadAllShootsForYear();
        }
        $scope.thisyear = true;
        
        $scope.loadCompetitions();

        $scope.changecomp();


    


}]);