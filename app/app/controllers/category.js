app.controller("categories", function($scope, $http, $route) {
    $scope.page_title = 'All Categories'
    $scope.data = []
    $http.get(routes.getAllCategories).then((res)=> {
        $scope.data = res.data;
        $scope.deleteCategory = (event) => {
            let cat_id = event.target.id
            $http.get(routes.deleteCategory(cat_id))
            $route.reload()
        }
    }).catch(err => {
        console.log("Server down")
    })
});
app.controller("addCategory", function($scope, $http) {
    $scope.page_title = 'Add Category'
    $scope.data = []
    $scope.success = null
    $scope.handleAddCategory = () => {
        toBase64(document.querySelector("#add_category input[type=file]").files[0]).then(base64Image => {
            console.log(base64Image)
            const data = new FormData()
            data.append('name', $scope.name)
            data.append('image', document.querySelector("#add_category input[type=file]").files[0])
            $http.post(routes.createCategory, data, {
                transformRequest: angular.identity,
                headers: {
                   "Content-Type": undefined
                }
             })
            .then(res => {
                console.log(res)
                $scope.success = "category created successfully"
            }).catch(err => {
                console.log(err)
            })
        })
        
    }
    $http.get(routes.getAllCategories).then((res)=> {
        $scope.data = res.data;
    })
});

const toBase64 = file => new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
});