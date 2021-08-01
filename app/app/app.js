var app = angular.module("myApp", ["ngRoute"]);
app.config(["$routeProvider","$locationProvider",function($routeProvider,$locationProvider) {

    $routeProvider
    .when("/", {
        templateUrl : "views/pages/home.html"
    })
    .when("/demo", {
        templateUrl : "views/pages/demopage.html",
        controller: 'demo'
    })
    .when("/products", {
        templateUrl: "views/pages/products.html",
        controller: 'products'
    })
    .when("/add_product", {
        templateUrl: "views/pages/add_product.html",
        controller: 'add_products'
    })
    .when("/edit_product/:id", {
        templateUrl: "views/pages/edit_product.html",
        controller: 'edit_product'
    })
    .when("/categories", {
        templateUrl: "views/pages/categories.html",
        controller: 'categories'
    })
    .when("/add_category", {
        templateUrl: "views/pages/add_category.html",
        controller: 'addCategory'
    })
    .when("/orders", {
        templateUrl: "views/pages/orders.html",
        controller: 'orders'
    })
    .when("/view_order/:id", {
        templateUrl: "views/pages/order_details.html",
        controller: 'view_order'
    })
    
    .otherwise({
        redirectTo:"/"
    });
      //$locationProvider.html5Mode(true);
      //$locationProvider.hashPrefix('');
      //if(window.history && window.history.pushState){
      //$locationProvider.html5Mode(true);
  //}

}]);
