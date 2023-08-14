using Newtonsoft.Json;
using SuperTiendaAbs;

namespace SuperTiendaAbs.Entities;

public class Product
{
    private int productId;
    private string productName;
    private int stock;
    private int minStock;
    private int maxStock;
    private double salePrice;
    private double purchasePrice;
    private int categoryId;

    public int ProductId { get => productId; set => productId = value; }
    public string ProductName { get => productName; set => productName = value; }
    public int Stock { get => stock; set => stock = value; }
    public int MinStock { get => minStock; set => minStock = value; }
    public int MaxStock { get => maxStock; set => maxStock = value; }
    public double SalePrice { get => salePrice; set => salePrice = value; }
    public double PurchasePrice { get => purchasePrice; set => purchasePrice = value; }
    public int CategoryId { get => categoryId; set => categoryId = value; }

    public static void AddProduct()
    {
        Product product = new();
        Console.WriteLine("-----Agregar Producto-----");

        product.ProductId = Env.MarketAbs.Products.Count + 1;
        Console.Write("Nombre: ");
        product.ProductName = Console.ReadLine();
        Console.Write("Stock actual: ");
        product.Stock = int.Parse(Console.ReadLine());
        Console.Write("Stock minimo: ");
        product.MinStock = int.Parse(Console.ReadLine());
        Console.Write("Stock maximo: ");
        product.MaxStock = int.Parse(Console.ReadLine());
        Console.Write("Precio de venta: ");
        product.SalePrice = double.Parse(Console.ReadLine());
        Console.Write("Precio de compra: ");
        product.PurchasePrice = double.Parse(Console.ReadLine());

        Console.Write("Id de categoria: ");
        product.CategoryId = int.Parse(Console.ReadLine());

        Env.MarketAbs.Products.Add(product);
        Console.WriteLine("Producto Agregado.");
    }

    // public void ViewProducts(List<Product> products)
    // {
    //     Console.WriteLine("{0, -3}  {1, -20} {2, -5}", "Id", "Nombre", "Stock");
    //     foreach (Product product in products)
    //     {
    //         Console.WriteLine("{0, 3}  {1, -20} {2, -5}", product.ProductId, product.ProductName, product.Stock);
    //     }
    // }

    public static void ViewInventary(List<Product> products)
    {
        var space = string.Concat(Enumerable.Repeat("-", 60));
        double total = 0;
        Console.WriteLine(" {0, -3}  {1, -20} {2, -6} {3, -12} {4, -12}", "Id", "Nombre", "Stock", "V/lor Unit", "Subtotal");

        foreach (Product product in products)
        {
            double subTotal = product.PurchasePrice * product.Stock;
            Console.WriteLine(" {0, 3}  {1, -20} {2, -6} {3, 12:C0} {4, 12:C0}", product.ProductId, product.ProductName, product.Stock, product.SalePrice, subTotal);
            total += subTotal;
        }
        Console.WriteLine(space);
        Console.WriteLine(" {0, 45} {1, 12:C0}", "Total Inventario", total);
    }
}