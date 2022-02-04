using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoAPI.Models;
using MongoAPI.Repositories;

namespace MongoAPI.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        public IProductCollection db = new ProductCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {

            return Ok(await db.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {

            return Ok(await db.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (product.Nombre == string.Empty)
            {

                ModelState.AddModelError("Nombre", "del producto esta vacio.");
            }

            await db.InsertProduct(product);

            return Created("Creado", true);

        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, string id)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (product.Nombre == string.Empty)
            {

                ModelState.AddModelError("Nombre", "del producto esta vacio.");
            }
            product.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateProduct(product);

            return Created("Actualizado", true);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await db.DeleteProduct(id);

            return NoContent();
        }

    }
}