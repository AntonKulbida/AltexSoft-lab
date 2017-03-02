app.controller("personController", function ($scope) {
    initLocalClocks();
    this.gender = "";
    if (localStorage.getItem("personsList") === null)
    {
        $scope.persons = [
            {
                "name"   : "Anton",
                "surname"  : "kulbida",
                "age"  : "23",
                "email": "anton.kulbida.work@gmail.com",
                "phone"   : "+380980459159",
                "gender"     : "male",
                "active"  : true
            },
        ];
        localStorage.setItem("personsList", angular.toJson($scope.persons));
    } else
    {
        $scope.persons = JSON.parse(localStorage.getItem("personsList"));
    }

    $scope.createPerson = function(person) {
        if($scope.personForm.$valid)
        {
            $scope.persons.push({
                "name" : person.name,
                "surname" : person.surname,
                "age"  : person.age,
                "email" : person.email,
                "phone" : person.phone,
                "gender"   : person.gender,
                "active" : true
            });
            localStorage.removeItem("personsList");
            localStorage.setItem("personsList", angular.toJson($scope.persons));
        }
    };

    $scope.changeActivity = function (person) {
        person.active = !person.active;
    };

    $scope.deletePerson = function (deletedPerson) {
        $scope.persons.forEach(function (person, i, persons) {
            if (person.name == deletedPerson.name
                && person.second == deletedPerson.second
                && person.email == deletedPerson.email
                && person.phone == deletedPerson.phone)
            {
                $scope.persons.splice(i,1);
            }
        });
        localStorage.removeItem("personsList");
        localStorage.setItem("personsList", angular.toJson($scope.persons));
    };
});