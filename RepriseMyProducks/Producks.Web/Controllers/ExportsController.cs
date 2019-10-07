using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Producks.Data;
using Producks.Web.Models;

namespace Producks.Web.Controllers
{
    [ApiController]
    public class ExportsController : ControllerBase
    {
        private readonly StoreDb _context;

        public ExportsController(StoreDb context)
        {
            _context = context;
        }

        // GET: api/Brands
        [HttpGet("api/Brands/{id?}")]
        public async Task<IActionResult> GetBrands(int? id)
        {
            var brands = await _context.Brands.Where(b => b.Id == id || id == null)
                                       .Select(b => new BrandDto
                                       {
                                           Id = b.Id,
                                           Name = b.Name,
                                           Active = b.Active
                                       })
                                       .ToListAsync();
            return Ok(brands);
        }

        // GET: api/Categories
        [HttpGet("api/Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var Categories = await _context.Categories
                                       .Select(c => new CategoryDto
                                       {
                                           Id = c.Id,
                                           Name = c.Name,
                                           Active = c.Active,
                                           Description = c.Description
                                       })
                                       .ToListAsync();
            return Ok(Categories);
        }

        // GET: api/Products
        [HttpGet("api/Products/{id?}")]
        public async Task<IActionResult> GetProducts(int? id)
        {
            var Products = await _context.Products.Where(p => p.CategoryId == id || id == null)
                                       .Select(p => new ProductsDto
                                       {
                                           Id = p.Id,
                                           Name = p.Name,
                                           Active = p.Active,
                                           Description = p.Description,
                                           BrandId = p.BrandId,
                                           Price = p.Price,
                                           StockLevel = p.StockLevel,
                                           CategoryId = p.CategoryId
                                       })
                                       .ToListAsync();
            return Ok(Products);
        }
    }
}
