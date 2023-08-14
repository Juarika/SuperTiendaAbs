using Newtonsoft.Json;
using SuperTiendaAbs.Entities;

namespace SuperTiendaAbs;

public static class Env
{
    private static string filename = "marketAbs.json";
    private static MarketAbs marketAbs = new();

    public static string Filename { get => filename; set => filename = value; }
    public static MarketAbs MarketAbs { get => marketAbs; set => marketAbs = value; }

    public static void LoadData(string filename)
    {            
        using StreamReader reader = new(filename);
        string json = reader.ReadToEnd();
        if (string.IsNullOrWhiteSpace(json)){
            _ = new MarketAbs();
            return;
        } else {
            MarketAbs = System.Text.Json.JsonSerializer.Deserialize<MarketAbs>(json, new System.Text.Json.JsonSerializerOptions()
            { PropertyNameCaseInsensitive = true }) ?? new MarketAbs();
        }
    }

    public static bool ValidateFile(string filename)
    {
        if (!File.Exists(filename))
        {
            return false;
        }
        return true;
    }

    public static void PrintData<T>(string title, IEnumerable<T> list)
    {
        Console.WriteLine("{0, -30}", title);
        foreach (var item in list)
        {
            Type classType = item.GetType();
            var properties = classType.GetProperties();
            foreach (var property in properties)
            {
                Console.Write($"  {property.Name}: {property.GetValue(item)}");
            }
        }
        Console.ReadKey();
    }

    public static void AddJson()
    {
        string json = JsonConvert.SerializeObject(MarketAbs, Formatting.Indented);
        File.WriteAllText(Filename, json);
    }
}