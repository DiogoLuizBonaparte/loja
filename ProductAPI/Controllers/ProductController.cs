using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data.ValueObjects;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var product = await _repository.FindAll();
            if (product == null) return NotFound();
            return Ok(product);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _repository.FindById(id);
            if (product.id <= 0) return NotFound();
            return Ok(product);

        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create(ProductVO vo)
        {

            if (vo == null) return BadRequest();
            var product = await _repository.Create(vo);
            return Ok(product);

        }
        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update(ProductVO vo)
        {

            if (vo == null) return BadRequest();
            var product = await _repository.Update(vo);
            return Ok(product);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductVO>> Delete(long id)
        {

           
            var status = await _repository.Delete(id);
            if (status == false) return BadRequest();
            return Ok(status);

        }


    }
}
