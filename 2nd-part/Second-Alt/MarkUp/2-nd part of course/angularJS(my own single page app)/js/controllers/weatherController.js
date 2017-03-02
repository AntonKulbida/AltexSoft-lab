app.controller("weatherController", function ($scope, $stateParams, $http) {
    //alert($stateParams.city);
    var api = "ee8dd8ba26f19994e2774787dcb33ae5";
    var units = "metric";
    var city = $stateParams.city;
    $scope.city = city;
    var language = "ru";
    var forecastUrl = "http://api.openweathermap.org/data/2.5/forecast/city?q="+city
        +"&lang="+language
        +"&units="+units
        +"&APPID="+api;
    //console.log(forecastUrl);
    $http({
        method: 'GET',
        url: forecastUrl
    }).then(function successCallback(response){
        //alert(response.data);
        $scope.weather = response.data;
    }, function errorCallback(response) {
        alert("Oops, something is wrong");
    });
});