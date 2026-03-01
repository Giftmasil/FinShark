using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository;

public class StockRepository(ApplicationDBContext context) : IStockRepository
{
    private readonly ApplicationDBContext _context = context;

    public async Task<List<Stock>> GetAllAsync()
    {
         return await _context.Stocks.ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await _context.Stocks.FindAsync(id);
    }

    public async Task<Stock> CreateAsync(Stock createStockModel)
    {
        _context.Stocks.Add(createStockModel);
        await _context.SaveChangesAsync();
        return createStockModel;
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockUpdateDto)
    {
        var existingStockModel = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
        if (existingStockModel is null)
        {
            return null;
        }

        existingStockModel.Symbol = stockUpdateDto.Symbol;
        existingStockModel.CompanyName = stockUpdateDto.CompanyName;
        existingStockModel.Purchase = stockUpdateDto.Purchase;
        existingStockModel.LastDiv = stockUpdateDto.LastDiv;
        existingStockModel.Industry = stockUpdateDto.Industry;
        existingStockModel.MarketCap = stockUpdateDto.MarketCap;

        await _context.SaveChangesAsync();
        return existingStockModel;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(stock => stock.Id == id);
        if (stockModel is null)
        {
            return null;
        }

        _context.Stocks.Remove(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }
}
