using Newtonsoft.Json;
namespace SuperTiendaAbs.Entities;

public class Category
{
    private int categoryId;
    private string categoryName;

    public int CategoryId { get => categoryId; set => categoryId = value; }
    public string CategoryName { get => categoryName; set => categoryName = value; }

    public static void AddCategory()
    {
        Category category = new();        
        Console.WriteLine("-----Agregar Categoria-----");

        category.CategoryId = Env.MarketAbs.Categories.Count + 1;
        Console.Write("Nombre: ");
        category.CategoryName = Console.ReadLine();

        Env.MarketAbs.Categories.Add(category);
        Console.WriteLine("Categoria Agregada.");
    }

    public static IEnumerable<Category> CategoriesList()
    {
        return from cat in Env.MarketAbs.Categories
            select cat;
    }

    public static void ViewCategories(List<Category> categories)
    {
        Console.WriteLine("{0, -3}  {1, -20}", "Id", "Nombre");
        foreach (Category category in categories)
        {
            Console.WriteLine("{0, 3}  {1, -20}", category.CategoryId, category.CategoryName);
        }
    }
}