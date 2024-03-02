namespace Entities;

public class Article : BaseEntity
{
    [Required, MaxLength(75)]
    public string StockKeepingUnit { get; set; } = string.Empty;

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "decimal(8,2)")]
    public decimal Price { get; set; }

    public override string ToString() => $"Name: {Name} | Price {Price}";
}