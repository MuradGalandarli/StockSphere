using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockSphere.Application.Feature.Command.Category.AddCategory;
using StockSphere.Application.Feature.Command.Category.UpdateCategory;

namespace StockSphere.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add-category")]
        public async Task<IActionResult>AddCategory(AddCategoryCommandRequest addCategoryCommandRequest)
        {
            AddCategoryCommandResponse addCategoryCommandResponse = await _mediator.Send(addCategoryCommandRequest);
            return Ok(addCategoryCommandResponse);
        }
        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse updateCategoryCommandResponse = await _mediator.Send(updateCategoryCommandRequest);
            return Ok(updateCategoryCommandResponse);
        }

    }
}
