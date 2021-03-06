﻿var myApp = angular.module('myApp', []);

$(document).ready(function () {
    $('.collapse').on('shown.bs.collapse', function () {
        $(this).parent().find(".glyphicon-plus").removeClass("glyphicon-plus").addClass("glyphicon-minus");
    }).on('hidden.bs.collapse', function () {
        $(this).parent().find(".glyphicon-minus").removeClass("glyphicon-minus").addClass("glyphicon-plus");
    });
    $('#searchButton').click(function () {
        var search = $('#usersSearch').val();
        $.post('../searchusers.php', { search: search }, function (response) {
            $('#userSearchResultsTable').html(response);
        });
    })
    $('#usersSearch').keypress(function (e) {
        if (e.which == 13) {//Enter key pressed
            $('#searchButton').click();//Trigger search button click event
        }
    });
});

//app.run(function (defaultErrorMessageResolver) {
//    defaultErrorMessageResolver.getErrorMessages().then(function (errorMessages) {
//        errorMessages['tooYoung'] = 'You must be at least {0} years old to use this site';
//        errorMessages['tooOld'] = 'You must be max {0} years old to use this site';
//        errorMessages['badUsername'] = 'Username can only contain numbers, letters and _';
//    });
//});

//app.controller('MinMaxCtrl', function ($scope, $http) {
//    $scope.formModel = {};
//    $scope.onSubmit = function () {
//        console.log("Hey I'm submitted!");
//        console.log($scope.formModel);

//        $http.post('', $scope.formModel).
//        success(function (data) {
//            console.log(":)")
//        }).error(function (data) {
//            console.log(":(")
//        });
//    };
//});


