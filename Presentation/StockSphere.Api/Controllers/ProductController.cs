using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockSphere.Application.Feature.Command.Product.AddProduct;
using System.Runtime.CompilerServices;

namespace StockSphere.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediat;

        public ProductController(IMediator mediat)
        {
            _mediat = mediat;
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(AddProductCommandRequest addProductCommandRequest)
        {
            AddProductCommandResponce addProductCommandResponce = await _mediat.Send(addProductCommandRequest);
            return Ok(addProductCommandResponce);   
        }
    }
}
