namespace SuperTiendaAbs.Views;

public class MainMenu
{
    public static int Menu()
    {
        Console.WriteLine("Super Tienda Abs");
        Console.WriteLine("1. Registrar Producto");
        Console.WriteLine("2. Registrar Categoria");
        Console.WriteLine("3. Listar Categorias");
        Console.WriteLine("4. Listar Productos");
        Console.WriteLine("5. Costo Total Inventario");
        Console.WriteLine("6. Salir");
        Console.Write("Seleccione una opcion: ");
        return int.Parse(Console.ReadLine());
    }
}