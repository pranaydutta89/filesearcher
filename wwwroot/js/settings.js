(function (window) {

    window.angularApp.controller('startController', ['$http', '$q', 'fileTypes', function ($http, $q, fileTypes) {
        var _this = this;


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