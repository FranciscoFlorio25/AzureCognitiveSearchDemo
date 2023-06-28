using Azure.Search.Documents;
using AzureCognitiveSearchDemo.Data;
using AzureCognitiveSearchDemo.DTO;
using AzureCognitiveSearchDemo.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzureCognitiveSearchDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly DemoContext _context;
        private readonly SearchClient _searchClient;
        public ProductsController(DemoContext context, SearchClient search)
        {
            _searchClient = search;
            _context = context;
        }

        // GET: api/<ProductsController>
        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok (products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            Products product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if(product == null)
            {
                return BadRequest("objeto no encontrado");
            }
            return Ok(product);
        }

        [HttpGet("product/search/{searchData}")]
        public async Task<IActionResult> SearchProduct(string searchData)
        {
            //Podemos buscar agregando filtros
            var options = new SearchOptions();

            options.Select.Add("Id");
            options.Select.Add("Name");
            options.Select.Add("Description");

            var results = await _searchClient.SearchAsync<ResultsDTO>(searchData);
            var products = results.Value.GetResultsAsync();
            return Ok(products.GetAsyncEnumerator());
        }


        // POST api/<ProductsController>
        [HttpPost("product")]
        public async Task<IActionResult> PostProduct([FromBody] string Name, string Description)
        {
            Products newProduct = new Products(Name,Description,DateTime.Now);

            await _context.Products.AddAsync(newProduct);

            _context.SaveChanges();

            return Ok("Producto Creado Satisfactoriamente");
        }



    }
}
