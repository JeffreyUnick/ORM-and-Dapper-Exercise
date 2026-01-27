using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);
            
            var repodept = new DapperDepartmentRepository(conn);
            
            // IMPLEMENTATION OF GetAllDepartment() JUST FOR FUN :)
            var departments = repodept.GetAllDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"{department.DepartmentID} - {department.Name}");
            }
            
            
            var repos = new DapperProductRepository(conn);
            
            // IMPLEMENTATION OF CreatAProduct()
            Console.WriteLine("What is the name of your product ?");
            var name = Console.ReadLine();

            Console.WriteLine("What is the categoryID of the product ?");
            var categoryID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the price of your product ?");
            var price = double.Parse(Console.ReadLine());
            
            repos.CreatAProduct(name, price, categoryID);
            
            
            // Implementation of GetAllProducts()
            var products = repos.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine($"{product.ProductID} - {product.Name} - {product.Price} - {product.CategoryID}");
            }
            
            // IMPLEMENTATION of UpdateProduct()
            
            Console.WriteLine("What is the productID of the product you want to update ?");
            var productID = int.Parse(Console.ReadLine());
            var productName = repos.QueryProductName(productID);
            Console.WriteLine($"You want to update :{productName}.\nWhat is the new name of this product ?");
            var newName = Console.ReadLine();
            repos.UpdateProduct(newName, productID);
            Console.WriteLine($"{newName} was updated");
            

            // IMPLEMENTATION of DeleteProduct()
            Console.WriteLine("What is the id of the product you want to delete ?");
            var id = int.Parse(Console.ReadLine());
            repos.DeleteProduct(id);
        }
        
    }
}
