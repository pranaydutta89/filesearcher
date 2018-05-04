(function (window) {

    window.angularApp.controller('startController', ['$http', '$q', function ($http, $q) {
        var _this = this;

        this.fileTypes = [{
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
        }]

        $http.get('/settings/folderList').then(function (res) {
            _this.folders = res.data;
        });

        $http.get('/settings/fileTypes').then(function (res) {
            res.data.forEach(function (r) {
                var obj = _this.fileTypes.find(function (e) {
                    return e.type === r.type;
                });
                if (obj) {
                    obj.selected = true;
                }
            });
        });

        this.updateFileTypes = function () {
            $http.put('/settings/fileTypes', _this.fileTypes.filter(function (r) {
                return r.selected;
            }));
        }

        this.addFolder = function () {
            _this.folders.push({ folderPath: _this.folderPath });
            _this.folderPath = "";
        }

        this.updateFolderList = function () {
            $http.put('/settings/folderList', _this.folders);
        }
    }]);

})(window)