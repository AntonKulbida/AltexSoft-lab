app.config(function($stateProvider, $urlRouterProvider) {
  
    $urlRouterProvider.otherwise('/home');
   
    $stateProvider.state('home', {
        url: '/home',
        templateUrl: 'templates/addPerson.html',
        controller: 'personController'
    })
    .state('list', {
        url: '/list',
        templateUrl: 'templates/listPersons.html',
        controller: 'personController'
    })
        .state('list.detail', {
            url: '/list.detail/{personEmail}',
            templateUrl: 'templates/personDetail.html',
            controller: 'personController'
        })
    .state('about', {
        url: '/about',
        templateUrl: 'templates/about.html',
        controller: 'personController'
    })
        .state('about.clocks', {
            url: '/about/clocks',
            templateUrl: 'templates/clocks.html',
            controller: 'personController'
        })
    .state('work', {
        url: '/work',
        templateUrl: 'templates/work.html',
        controller: 'personController'
    })
        .state('work.author', {
            url: '/work/author',
            templateUrl: 'templates/author.html',
            controller: 'personController'
        });

});


