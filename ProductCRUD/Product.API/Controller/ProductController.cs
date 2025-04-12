using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Application.DTOs;
using Product.Application.Interfaces;

namespace Product.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id, CancellationToken cancellationToken)
        {
            ResponseDto<ProductDto> response = await _productService.GetProductByIdAsync(id, cancellationToken);

            if (response.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(response.Data);
            }
            else if (response.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(response);
            }
            else
            {
                return StatusCode(response.StatusCode, response);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            ResponseDto<List<ProductDto>> response = await _productService.GetAllProductsAsync(cancellationToken);

            if (response.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(response.Data);
            }
            else if (response.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(response);
            }
            else
            {
                return StatusCode(response.StatusCode, response);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(ProductDto productDto, CancellationToken cancellationToken)
        {
            ResponseDto<object> response = await _productService.AddProductAsync(productDto, cancellationToken);

            if (response.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(response);
            }
            else if (response.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(response);
            }
            else
            {
                return StatusCode(response.StatusCode, response);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(ProductDto productDto, CancellationToken cancellationToken)
        {
            ResponseDto<object> response = await _productService.UpdateProductAsync(productDto, cancellationToken);

            if (response.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(response);
            }
            else if (response.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(response);
            }
            else
            {
                return StatusCode(response.StatusCode, response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            ResponseDto<object> response = await _productService.DeleteProductAsync(id, cancellationToken);

            if (response.StatusCode == StatusCodes.Status200OK)
            {
                return Ok(response);
            }
            else if (response.StatusCode == StatusCodes.Status400BadRequest)
            {
                return BadRequest(response);
            }
            else
            {
                return StatusCode(response.StatusCode, response);
            }
        }
    }
}
