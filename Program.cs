using Newtonsoft.Json;
using SuperTiendaAbs;
using SuperTiendaAbs.Entities;
using SuperTiendaAbs.Views;

internal class Program
{
    private static void Main()
    {
        int option;
        if (Env.ValidateFile(Env.Filename) == false)
        {
            File.WriteAllText(Env.Filename, "");
        } else {
            Env.LoadData(Env.Filename);
        }
        
        do
        {
            Console.Clear();
            option = MainMenu.Menu();
            switch (option)
            {
                case 1:
                    Product.AddProduct();
                    Env.AddJson();
                    Console.ReadKey();
                    break;
                case 2:
                    Category.AddCategory();
                    Env.AddJson();
                    Console.ReadKey();
                    break;
                case 3:
                    Env.PrintData("Categorias", Env.MarketAbs.Categories);
                    break;
                case 4:
                    Env.PrintData("Productos", Env.MarketAbs.Products);
                    break;
                case 5:
                    Product.ViewInventary(Env.MarketAbs.Products);
                    Console.ReadKey();
                    break;
                case 6:
                    Console.WriteLine("Adios");
                    break;
                default:
                    Console.WriteLine("Opcion Incorrecta");
                    break;
            }
        }while (option != 6);
    }
}