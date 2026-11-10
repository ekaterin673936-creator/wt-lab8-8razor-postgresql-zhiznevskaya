namespace wt_lab8_8razor_postgresql_zhiznevskaya.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public bool IsAvailable { get; set; } = true;
    
    // Новое поле для Блока 5
    public string Description { get; set; } = string.Empty;
}