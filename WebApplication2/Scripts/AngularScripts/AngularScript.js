var app = angular.module('TestApp', []);
app.factory('customerCallFactory', ['$http', function ($http) {
    var getCustomer = function () {
        return $http({
            method: 'GET',
            url: '/Customers/GetCustomers',
            cache: false
        }).success(function (resp) {
            return resp;
        }).error(function () { });
    };
    var delCustomer = function (customers) {
        return $http({
            method: 'DELETE',
            url: '/Customers/DeleteCustomers',
            data: customers,
            cache: false
        }).success(function (resp) {
            return resp;
        }).error(function () { });
    };
    var addCustomer = function (customers) {
        return $http({
            method: 'POST',
            url: '/Customers/InsertCustomers',
            data: customers,
            cache: false
        }).success(function (resp) {
            return resp;
        }).error(function () { });
    };
    var updateCustomer = function (customers) {
        return $http({
            method: 'PUT',
            url: '/Customers/UpdateCustomers',
            data: customers,
            cache: false
        }).success(function (resp) {
            return resp;
        }).error(function () { });
    };
    return {
        getCustomer: getCustomer,
        delCustomer: delCustomer,
        addCustomer: addCustomer,
        updateCustomer: updateCustomer
    };
}])
.service('customerCallSvc', ['customerCallFactory', function (customerCallFactory) {
    return {
        getCustomer: function () {
            return customerCallFactory.getCustomer();
        },
        delCustomer: function (idens) {
            return customerCallFactory.delCustomer(idens);
        },
        addCustomer: function (customers) {
            return customerCallFactory.addCustomer(customers);
        },
        updateCustomer: function (customers) {
            return customerCallFactory.updateCustomer(customers);
        }
    };
}])
    .controller('TestController', ['$scope', '$q', 'customerCallSvc', function ($scope, $q, customerCallSvc) {
    $scope.TestText = 'Test';
    $scope.NewName = '';
    $scope.NewBirthday = '';
    $scope.customers = [];
    /* Test Data
        [{ Iden: 11, Name: 'Test1', Birthday: '2021-12-28' },
        { Iden: 22, Name: 'Test2', Birthday: '2021-12-28' },
        { Iden: 33, Name: 'Test3', Birthday: '2021-12-28' }]
    */
    customerCallSvc.getCustomer().then(function (resp) {
        if (resp && resp.data) {
            $scope.customers = resp.data;
            $scope.customers.forEach(function (customer) { return customer.Birthday = customer.Birthday.split('T')[0]; });
        }
    });
    var delData = [];
    var updateData = [];
    var editorPosition = '';
    $scope.deleteCustomer = function (idx) {
        delData.push(this.customer.Iden);
        $scope.customers.splice(idx, 1);
    }

    $scope.addCustomer = function ($event) {
        $scope.customers.push({ Iden: 0, Name: $scope.NewName, Birthday: $scope.NewBirthday });
        $scope.NewName = '';
        $scope.NewBirthday = '';
    }
    $scope.editCustomer = function ($event) {
        if (!updateData.find(function (id) { return id == this.customer.Iden; })) {
            updateData.push(this.customer.Iden);
        }
        editorPosition = $($event.currentTarget).attr('name') + '_' + this.$index;
    }
    $scope.editMode = function (positionIndex) {
        return editorPosition == positionIndex;
    }

    $scope.initialField = function () {
        editorPosition = '';
    }

    $scope.submitForm = function ($event) {
        // delData DeleteCustomer
        var promiseList = [];
        if (delData && delData.length != 0) {
            var delCust = [];
            delData.forEach(function (id) {
                //remove deleted data from update list
                if (updateData && updateData.indexOf(id) != -1) {
                    updateData.splice(updateData.indexOf(id), 1);
                }
                //build empty customer to delete
                delCust.push({ Iden: id, Name: '', Birthday: '0001-01-01' });
            });
            promiseList.push(customerCallSvc.delCustomer(delCust));
        }
        // addCustomers
        var newCust = $scope.customers.filter(function (cust) { return cust.Iden == 0; });
        promiseList.push(customerCallSvc.addCustomer(newCust));

        var updateCust = $scope.customers.filter(function (cust) { return updateData.indexOf(cust.Iden) != -1; });
        promiseList.push(customerCallSvc.updateCustomer(updateCust));
        $q.all(promiseList).then(function () {

        });
    }
}]);