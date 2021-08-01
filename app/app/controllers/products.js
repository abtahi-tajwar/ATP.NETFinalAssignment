app.controller("products",function($scope,$http,$route){
    $scope.page_title = 'Products'
    $scope.products = []
    $http.get(routes.getAllProducts).then(res => {
        $scope.products = res.data
    })  
    
    $scope.deleteProduct = event => {
        let p_id = event.target.id
        $http.get(routes.deleteProduct(p_id))
        $route.reload()
    }
});
app.controller("add_products", function($scope, $http) {
    $scope.page_title = 'Add Products'
    $scope.categories = []
    $http.get(routes.getAllCategories).then(res => {
        $scope.categories = res.data
        console.log($scope.categories)
    })    
    $scope.handleAddProduct = () => {

        const data = new FormData()
        data.append('name', $scope.name)
        data.append('category_id', $scope.category_id)
        data.append('price', $scope.price)
        data.append('qty', $scope.qty)
        data.append('description', $scope.description)
        data.append('image', document.querySelector("#add_product input[type=file]").files[0])

        //console.log($scope.name, $scope.category_id, $scope.price, $scope.description, document.querySelector("#add_product input[type=file]").files[0])

        $http.post(routes.createProduct, data, {
            transformRequest: angular.identity,
                headers: {
                    "Content-Type": undefined
                }
            })
        .then(res => {
            console.log(res)
            $scope.success = "Product created successfully"
        }).catch(err => {
            console.log(err)
        })
    }
    
});

app.controller("edit_product", function($scope, $http, $routeParams) {
    $scope.page_title = 'Add Products'
    $scope.categories = []
    $scope.select_cat = false
    $http.get(routes.getProduct($routeParams.id)).then(res => {
        const data = res.data
        $scope.name = data.name
        $scope.category_name = data.category_name
        $scope.category_id = data.category_id
        $scope.price = data.price
        $scope.qty = data.qty
        $scope.description = data.description
        $scope.image = data.image
        
        $http.get(routes.getAllCategories).then(res => {
            $scope.categories = res.data
            $scope.categories.forEach(cat => {
                if(cat.id === $scope.category_id) {
                    $scope.select_cat = true
                }
            });
        })  
    })
      
    $scope.handleAddProduct = () => {

        const data = new FormData()
        data.append('id', $routeParams.id)
        data.append('name', $scope.name)
        data.append('category_id', $scope.category_id)
        data.append('price', $scope.price)
        data.append('qty', $scope.qty)
        data.append('description', $scope.description)
        data.append('image', document.querySelector("#add_product input[type=file]").files[0])
        $http.post(routes.editProduct, data, {
            transformRequest: angular.identity,
                headers: {
                    "Content-Type": undefined
                }
            })
        .then(res => {
            console.log(res)
            $scope.success = "Product created successfully"
        }).catch(err => {
            console.log(err)
        })
    }
    
});
