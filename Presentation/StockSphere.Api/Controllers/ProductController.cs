using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockSphere.Application.Feature.Command.Product.AddProduct;
using StockSphere.Application.Feature.Command.Product.DeleteProduct;
using StockSphere.Application.Feature.Command.Product.UpdateProduct;
using StockSphere.Application.Feature.Query.Product.GetAllProduct;
using StockSphere.Application.Feature.Query.Product.GetProduct;
using StockSphere.Application.Feature.Query.Product.SearchProduct;
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
        public async Task<IActionResult> AddProduct([FromBody]AddProductCommandRequest addProductCommandRequest)
        {
            AddProductCommandResponce addProductCommandResponce = await _mediat.Send(addProductCommandRequest);
            return Ok(addProductCommandResponce);   
        }
        //[Authorize]
        [HttpGet("get-all-product")]
        public async Task<IActionResult> GetAllProduct([FromQuery]GetAllProductQueryRequest allProductCommandRequest)
        {
            List<GetAllProductQueryResponse> getAllProductCommandResponse = await _mediat.Send(allProductCommandRequest);
            return Ok(getAllProductCommandResponse);
        }
        [HttpGet("get-product")]
        public async Task<IActionResult> GetProduct([FromQuery]GetProductQueryRequest getProductCommandRequest)
        {
            GetProductQueryResponse getProductCommandResponse = await _mediat.Send(getProductCommandRequest);
            return Ok(getProductCommandResponse);
        }
        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct([FromBody]UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse updateProductCommandResponse = await _mediat.Send(updateProductCommandRequest);
            return Ok(updateProductCommandResponse);
        }
        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct([FromQuery]DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductCommandResponse deleteProductCommandResponse = await _mediat.Send(deleteProductCommandRequest);
            return Ok(deleteProductCommandResponse);
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] SearchQueryRequest searchQueryRequest)
        {
            SearchQueryResponse searchQueryResponse = await _mediat.Send(searchQueryRequest);
            return Ok(searchQueryResponse);
        }


    }
}
