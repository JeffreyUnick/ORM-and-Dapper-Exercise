namespace ORM_Dapper;

public interface IProductRepository
{
    public IEnumerable<Product> GetAllProducts();
    public void CreatAProduct(string name, double price, int categoryID);
    public void UpdateProduct(string name, int productID); 
    public void DeleteProduct(int productID);
}