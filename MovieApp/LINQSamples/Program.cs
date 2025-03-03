using LINQSamples.Data;

class ProductModel
{
    public string Name { get; set; }
    public float? Price { get; set; }
    
}
class Program
{
    static void Main(string[] args)
    {
        using (var db = new NorthwindContext())
        {
            
            
        }

        Console.ReadLine();
    }

    private static void ders3(NorthwindContext db)
    {
        //tüm müşteri kayıtlarını getiriniz 

        // var customers = db.Customers.ToList();
        //tüm müşterilerin sadece CustomerId ve ContactName kolonlarını geitr
        // var customers = db.Customers.Select(c=>new {c.CustomerId,c.ContactName}).ToList();
        //almanyada yaşayan müşteri adları 
        // var customers = db.Customers.Where(c => c.Country == "Germany").Select(c=>new {c.Country,c.ContactName}).ToList();
        // 
        // var customers = db.Customers.Where(c => c.ContactName == "Diego Roel").Select(c=>new {c.Address,c.ContactName}).ToList();
        // var customers = db.Products.Where(c => c.UnitsInStock == 0).Select(c=>new {c.ProductName,c.UnitsInStock}).ToList();
        var customers = db.Employees.Select(c=>new {Fullname=c.FirstName+c.LastName}).ToList();
        // var customers = db.Products.Select(c=>new {c.ProductName,c.ProductId}).Take(5).ToList();
        // var customers = db.Products.Select(c=>new {c.ProductName}).Skip(5).Take(5).ToList();

        foreach (var p in customers)
        {
            Console.WriteLine(p.Fullname);
                
        }
    }

    private static void Ders1(NorthwindContext db)
    {
        //  var products = db.Products.ToList();
        // var products = db.Products.Select(p=>p.ProductName).ToList();
        // var products = db.Products.Select(p=>new{p.ProductName,p.UnitPrice}).ToList();
        // var products = db.Products.Select(p=>
        //     new ProductModel
        //     {
        //         Name = p.ProductName,
        //         Price = p.UnitPrice
        //     }).ToList();
        // var product = db.Products.First();
        var product = db.Products.Select(p=>new{p.ProductName,p.UnitPrice}).FirstOrDefault();
        Console.WriteLine(product.ProductName+' '+product.UnitPrice);
        // foreach (var p in products)
        // {
        //     Console.WriteLine(p.Name+' '+p.Price);
        // }
    }
}