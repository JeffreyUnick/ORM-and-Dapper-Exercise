namespace ORM_Dapper;

public class Product
{
    public Product(){}
    
    public string Name { get; set; }
    public int ProductID { get; set; }
    public double Price { get; set; }
    public string StockLevel { get; set; }
    public int CategoryID { get; set; } 
    
}