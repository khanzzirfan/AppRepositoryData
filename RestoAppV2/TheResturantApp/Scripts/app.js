var ViewModel = function () {
    var self = this;
    self.error = ko.observable();

    //Customers
    self.customers = ko.observableArray();
    self.detail = ko.observable();

    //Orders;
    self.orders = ko.observableArray();
    self.orderdetail = ko.observable();

    self.newCustomer = {
        Name: ko.observable(),
        Phone: ko.observable(),
        InsertDateTime: ko.observable(),
        InsertUser: ko.observable(),
        InsertProcess: ko.observable(),
    }

    self.newOrder = {
        Customer: ko.observable(),
        TotalAmount: ko.observable(),
        TaxAmount: ko.observable(),
        NetAmount: ko.observable(),
        Comments: ko.observable(),
        InsertDateTime: ko.observable(),
        InsertUser: ko.observable(),
        InsertProcess: ko.observable()
    }

    var customersUri = '/api/customers/';
    var ordersUri = '/api/Orders/';


    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllCustomers() {
        ajaxHelper(customersUri, 'GET').done(function (data) {
            self.customers(data);
        });
    }

    self.getCustomerDetail = function (item) {
        ajaxHelper(customersUri + item.CustomerId, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.addCustomer = function (formElement) {
        var customer = {
            Name: self.newCustomer.Name(),
            Phone: self.newCustomer.Phone(),
            InsertDateTime: self.newCustomer.InsertDateTime(),
            InsertUser: self.newCustomer.InsertUser(),
            InsertProcess:self.newCustomer.InsertProcess()
        };
        ajaxHelper(customersUri, 'POST', customer).done(function(item) {
            self.customers.push(item);
        });
    }

    /*** All about Orders   ***/
    function getAllOrders() {
        ajaxHelper(ordersUri, 'GET').done(function(data) {
            self.orders(data);
        });
    }

    self.getOrderDetail = function (item) {
        ajaxHelper(ordersUri + item.Id, 'GET').done(function (data) {
            self.orderdetail(data);
        });
    }

    self.addOrder = function (formElement) {
        var orders = {
            CustomerId: self.newOrder.Customer().CustomerId,
            TotalAmount: self.newOrder.TotalAmount(),
            TaxAmount: self.newOrder.TaxAmount(),
            NetAmount: self.newOrder.NetAmount(),
            Comments: self.newOrder.Comments(),
            InsertDateTime: self.newOrder.InsertDateTime(),
            InsertUser: self.newOrder.InsertUser(),
            InsertProcess: self.newOrder.InsertProcess()
        };
        ajaxHelper(ordersUri, 'POST', orders).done(function(item) {
            self.orders.push(item);
        });
    }

    // Fetch the initial data.
    getAllCustomers();
    getAllOrders();
};

ko.applyBindings(new ViewModel());