namespace api.Dtos.Stock;

public record class StockDto
(
    int Id,
    string Symbol,
    string CompanyName,
    decimal Purchase,
    decimal LastDiv,
    string Industry,
    long MarketCap 
);
