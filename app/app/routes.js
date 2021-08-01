const base = `https://localhost:44301`
const routes = {
    getAllCategories: `${base}/api/Category/getAll`,
    getCategory: (id => `${base}/api/Category/${id}`),
    createCategory: `${base}/api/Category/create`,
    editCategory: `${base}/api/Category/edit`,
    deleteCategory: (id => `${base}/api/Category/delete/${id}`),
    getAllProducts: `${base}/api/Product/GetAll`,
    getProduct: (id => `${base}/api/Product/${id}`),
    deleteProduct: (id => `${base}/api/Product/delete/${id}`),
    createProduct: `${base}/api/Product/create`,
    editProduct: `${base}/api/Product/edit`,
    getAllOrders: `${base}/api/Order/getAll`,
    getOrder: (id => `${base}/api/Order/${id}`)
}