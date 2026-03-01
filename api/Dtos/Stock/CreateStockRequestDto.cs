using System;

namespace api.Dtos.Stock;

public record class CreateStockRequestDto
(
    string Symbol,
    string CompanyName,
    decimal Purchase,
    decimal LastDiv,
    string Industry,
    long MarketCap 
);
