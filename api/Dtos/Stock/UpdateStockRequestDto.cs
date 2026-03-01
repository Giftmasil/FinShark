namespace api.Dtos.Stock;

public record class UpdateStockRequestDto
(
    string Symbol,
    string CompanyName,
    decimal Purchase,
    decimal LastDiv,
    string Industry,
    long MarketCap 
);
