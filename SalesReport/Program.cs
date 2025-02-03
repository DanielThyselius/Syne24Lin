// This is NOT how you should be coding!

var db = new Database();
var fileWriter = new FileWriter();
var products = db.GetAllProducts();
var categories = db.GetAllCategories();

foreach (var category in categories)
{
    var categoryName = category.Name;
    var categoryProducts = products.Where(p => p.CategoryId == category.Id);
    var totalRevenue = categoryProducts.Sum(p => p.Price * p.UnitsSold);
    var reportContent = $"Category: {categoryName}\nTotal Revenue: {totalRevenue}\n\nProducts:\n";

    foreach (var product in categoryProducts)
    {
        reportContent += $"- {product.Name}: {product.UnitsSold} units sold, revenue: {product.Price * product.UnitsSold}\n";
    }

    fileWriter.WriteToFile($"report_{categoryName}.txt", reportContent);
}

public class Database
{
    // Let's pretend this actually connects to a database
    public List<Product> GetAllProducts() => new List<Product>
    {
        new Product { Id = 1, Name = "Product A", CategoryId = 1, Price = 10, UnitsSold = 100 },
        new Product { Id = 2, Name = "Product B", CategoryId = 1, Price = 20, UnitsSold = 50 },
        new Product { Id = 3, Name = "Product C", CategoryId = 2, Price = 15, UnitsSold = 75 }
    };

    public List<Category> GetAllCategories() => new List<Category>
    {
        new Category { Id = 1, Name = "Category 1" },
        new Category { Id = 2, Name = "Category 2" }
    };
}

public class FileWriter
{
    public void WriteToFile(string fileName, string content)
    {
        // Let's pretend this actually writes to a file
        Console.WriteLine($"Writing to file '{fileName}':\n{content}");
    }
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public decimal Price { get; set; }
    public int UnitsSold { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}
