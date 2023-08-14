namespace SuperTiendaAbs.Entities;

public class MarketAbs
{
    private List<Product> products = new();
    private List<Category> categories = new();

    public List<Product> Products { get => products; set => products = value; }
    public List<Category> Categories { get => categories; set => categories = value; }

    public MarketAbs(){}
}