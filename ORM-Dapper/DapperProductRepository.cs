using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public DapperProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM Products;");
    }

    public void CreatAProduct(string name, double price, int categoryID)
    {
        _connection.Execute("INSERT INTO Products (Name, Price, CategoryID)" +
                            " VALUES (@Name, @Price, @CategoryID);",
            new {Name = name, Price = price, CategoryID = categoryID});
    }

    public void UpdateProduct(string name, int productID)
    {
        _connection.Execute("UPDATE Products SET Name = @Name WHERE ProductID = @productID;",
            new {Name = name, ProductID = productID});
    }
    public void DeleteProduct(int productID)
    {
        _connection.Execute("DELETE FROM products WHERE ProductID = @ProductID;", new {ProductID = productID});
    }

    // ADDITIONNAL JUST FOR FUN :)
    public string? QueryProductName(int productID)
    {
        return _connection.QueryFirstOrDefault<string>("SELECT Name FROM Products WHERE ProductID = @productID;",
            new { ProductID = productID});
    }
   //Claude sonnet
}