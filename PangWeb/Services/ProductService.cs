using PangWeb.Shared;
using System.Text.Json;

namespace PangWeb.Services;

public class ProductService
{
    private readonly HttpClient _httpClient;
    public List<Product> products;
    public List<ProductCategory> productCategories;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /* Get a product by its ID */
    public Product GetProductById(long id)
    {
        // TODO
        return new Product();
    }

    /* Get product categories */
    public async Task<List<ProductCategory>> GetProductCategories()
    {
        return new List<ProductCategory>();
        var requestMsg = new HttpRequestMessage(HttpMethod.Get, "api/Product/GetProductCategories");
        var response = await _httpClient.SendAsync(requestMsg);

        if (response.IsSuccessStatusCode)
            return await JsonSerializer.DeserializeAsync<List<ProductCategory>>(await response.Content.ReadAsStreamAsync());
        return new List<ProductCategory>();
    }

    /* Get List of all _products */
    public async Task<List<Product>> GetAllProducts()
    {
        return new List<Product>();
        var requestMsg = new HttpRequestMessage(HttpMethod.Get, "api/Product/GetProducts");
        var response = await _httpClient.SendAsync(requestMsg);

        if (response.IsSuccessStatusCode)
            return await JsonSerializer.DeserializeAsync<List<Product>>(await response.Content.ReadAsStreamAsync());
        return new List<Product>();
    }

    /* Get List of all products by category */
    public List<Product> GetAllProductsByCategory(long categoryId)
    {
        // TODO
        //return _products.OrderByDescending(x => x.DateAdded)
        //    .Where(x => x.Active && (x.ProductCategoryId == categoryId || categoryId == productCategories.First(x => x.Category == "All").Id))
        //    .Join(
        //        productCategories,
        //        p => p.ProductCategoryId,
        //        pc => pc.Id,
        //        (product, category) => new Product(product, category)
        //        )
        //    .ToList();
        return new List<Product>();
    }

    /* Get List of all products */
    public List<Product> GetAllProductsAdmin()
    {
        // TODO
        return new List<Product>();
    }

    /* Add a new products to the list */
    public bool AddNewProduct(Product productForm)
    {
        // TODO
        //if (productForm.Name != null && productForm.Description != null)
        //{
        //    productForm.DateAdded = DateTimeOffset.Now;
        //    productForm.Id = ++idTracker;
        //    _products.Add(productForm);
        //    return true;
        //}
        return false;
    }

    /* Save editted product from list */
    public bool SaveEdittedProduct(Product productForm)
    {
        // TODO
        //if (productForm != null)
        //{
        //    var productIndex = _products.FindIndex(x => x.Id == productForm.Id);
        //    _products[productIndex] = productForm;
        //    return true;
        //}
        return false;
    }

    /* Disable _products from list */
    public void DeleteProduct(Product productForm)
    {
        // TODO
        //if (productForm != null)
        //{
        //    var productIndex = _products.FindIndex(x => x.Id == productForm.Id);
        //    _products[productIndex].Active = false;
        //}
    }

    /* Reactivate _products from list */
    public void ReactivateProduct(Product productForm)
    {
        // TODO
        //if (productForm != null)
        //{
        //    var productIndex = _products.FindIndex(x => x.Id == productForm.Id);
        //    _products[productIndex].Active = true;
        //}
    }
    public long GetCategoryId(string category)
    {
        // TODO
        //var productCategory = productCategories.Where(x => x.Category == category).First();
        //if (productCategory != null) return productCategory.Id;
        return 0;
    }
}
