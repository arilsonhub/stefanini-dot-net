$("#lastPurchaseBegin").mask("99/99/9999");
$("#lastPurchaseEnd").mask("99/99/9999");

app.controller('customerController', function ($scope, $http) {

    $scope.showSellers = false;

    $scope.clearFields = function () {
        $scope.name = "";
        $scope.cityId = "";
        $scope.genderId = "";
        $scope.regionId = "";
        $scope.sellerId = "";
        $scope.lastPurchaseBegin = "";
        $scope.lastPurchaseEnd = "";
        $scope.classificationId = "";
    }

    $scope.getCustomers = function () {

        var requestData = {
            "name": $scope.name,
            "cityId": $scope.cityId,
            "genderId": $scope.genderId,
            "regionId": $scope.regionId,
            "sellerId": $scope.sellerId,
            "lastPurchaseBegin": $scope.lastPurchaseBegin,
            "lastPurchaseEnd": $scope.lastPurchaseEnd,
            "classificationId": $scope.classificationId
        };     

        showHideLoader(true, function () {
            $http.post('Customer/getCustomers', requestData)
                .success(function (customersData) {
                    $scope.customersData = customersData;
                    showHideLoader(false);
                })
                .error(function () {
                    showUIAlert("There was an error listing customers.");
                    showHideLoader(false);
                });
        });
    }

    $scope.getCitiesByRegionId = function () {

        var requestData = {            
            "regionId": $scope.regionId,            
        };
        
        $http.post('Customer/getCities', requestData)
            .success(function (citiesData) {
                $scope.citiesData = citiesData;                    
            })
            .error(function () {
                showUIAlert("There was an error listing cities.");                    
            });        
    }

    $scope.getGenders = function () {
        $http.post('Customer/getGenders')
            .success(function (gendersData) {
                $scope.gendersData = gendersData;                
            });         
    }

    $scope.getRegions = function () {
        $http.post('Customer/getRegions')
            .success(function (regionsData) {
                $scope.regionsData = regionsData;
            });
    }

    $scope.getSellers = function () {
        $http.post('Customer/getSellers')
            .success(function (sellersData) {
                if (sellersData.length > 0) {
                    $scope.sellersData = sellersData;
                    $scope.showSellers = true;
                }   
            });
    }

    $scope.getClassifications = function () {
        $http.post('Customer/getClassifications')
            .success(function (classificationsData) {
                $scope.classificationsData = classificationsData;
            });
    }

    $scope.getCustomers();
    $scope.getGenders();
    $scope.getRegions();    
    $scope.getClassifications();
    $scope.getSellers();
});