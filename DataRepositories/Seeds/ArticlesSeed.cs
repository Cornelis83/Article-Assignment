namespace DataRepositories.Seeds;

internal static class ArticlesSeed
{
    private static readonly IEnumerable<Article> articles = 
    [
        Create(1, "Excavator", "LEGO-42100", 449.99m),
        Create(2, "Lamborghini Sián", "LEGO-42115", 399.99m),
        Create(3, "Millennium Falcon", "LEGO-75192", 849.99m),
        Create(4, "Verkenningsrover op Mars", "LEGO-42180", 149.99m),
        Create(5, "Concorde", "LEGO-10318", 119.99m),
        Create(6, "Treinrails", "LEGO-60205", 19.99m),
        Create(7, "Wissels", "LEGO-60238", 19.99m),
        Create(8, "Passagierssneltrein", "LEGO-60337", 159.99m),
        Create(9, "Titanic", "LEGO-10294", 679.99m),
        Create(10, "Lego Minifiguren serie", "LEGO-71045", 3.99m)
    ];

    internal static void Execute(ModelBuilder modelBuilder)
        => modelBuilder.Entity<Article>().HasData(articles);

    private static Article Create(int id, string name, string stockKeepingUnit, decimal price)
        => new() 
           { 
                Id = id,
               Name = name, 
               StockKeepingUnit = stockKeepingUnit, 
               Price = price 
           };
}
