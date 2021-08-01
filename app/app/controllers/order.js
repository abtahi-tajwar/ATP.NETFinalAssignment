app.controller("orders", function($scope, $http) {
    $scope.page_title = 'All Orders'
    $scope.index = 1
    $http.get(routes.getAllOrders).then(res => {
        $scope.orders = res.data
        $scope.orders = $scope.orders.map(order => {
            let date = new Date(order.created_at)
            let fullDate = `${date.getDate()}-${date.getMonth()}-${date.getFullYear()}`
            let time = `${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}`;
            return {...order, date: fullDate, time: time}
        })
    })
})
app.controller("view_order", function($scope, $http, $routeParams) {
    $scope.page_title = "View Order"
    $http.get(routes.getOrder($routeParams.id)).then(res => {
        $scope.order_details = res.data
        $scope.total = 0
        $scope.order_details.products.forEach(product => {
            $scope.total += product.price * product.qty
        })
        $scope.total += $scope.order_details.delivery_charge
    })
})