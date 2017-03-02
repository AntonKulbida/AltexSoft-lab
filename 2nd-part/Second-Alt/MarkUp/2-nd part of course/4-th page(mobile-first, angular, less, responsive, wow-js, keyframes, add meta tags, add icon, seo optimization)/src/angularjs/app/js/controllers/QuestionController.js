questApp.controller('QuestionController', 
    function QuestionController($scope){
     
        $scope.question={
            answers: 
            [{ rate:5 }]
        },

        $scope.voteUp = function (answer){
            answer.rate++;
        };

        $scope.voteDown = function (answer){
            answer.rate--;
        };
    }
)