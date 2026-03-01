using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController(ApplicationDBContext context) : ControllerBase
    {
        private readonly ApplicationDBContext _context = context;

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks =  _context.Stocks
                .Select(s => s.ToStockDto())
                .ToList();
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);

            if (stock is null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockCreateDto)
        {
            var stockModel = stockCreateDto.ToStockFromCreateDTO();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id}, stockModel.ToStockDto());
        }

        /* [HttpPut]
        [Route("{id}")] */
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto stockUpdateDto )
        {
            var stockModel = _context.Stocks.FirstOrDefault(stock => stock.Id == id);
            if (stockModel is null)
            {
                return NotFound();
            }

            stockModel.Symbol = stockUpdateDto.Symbol;
            stockModel.CompanyName = stockUpdateDto.CompanyName;
            stockModel.Purchase = stockUpdateDto.Purchase;
            stockModel.LastDiv = stockUpdateDto.LastDiv;
            stockModel.Industry = stockUpdateDto.Industry;
            stockModel.MarketCap = stockUpdateDto.MarketCap;

            _context.SaveChanges();
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stockModel = _context.Stocks.FirstOrDefault(stock => stock.Id == id);
            if (stockModel is null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stockModel);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
