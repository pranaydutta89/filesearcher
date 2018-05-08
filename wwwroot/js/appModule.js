(function (angular) {

    var angularApp = angular.module('app', []);

    angularApp.constant('fileTypes', [{
        type: 1,
        title: "Audio"
    }, {
        type: 2,
        title: "Video"
    }, {
        type: 3,
        title: "Docuemnts"
    }, {
        type: 5,
        title: "Images"
    }, {
        type: 4,
        title: "ALL"
    }]);

    window.angularApp = angularApp;

})(angular)