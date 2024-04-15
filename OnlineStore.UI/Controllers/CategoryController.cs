using OnlineStore.BLL.Services.Interfaces;
using OnlineStore.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace OnlineStore.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        [SwaggerOperation("Create a new category")]
        [ProducesResponseType(typeof(CreateCategoryDTO), 200)]
        public async Task<ActionResult<CreateCategoryDTO>> CreateCategoryAsync(CreateCategoryDTO newCategory, CancellationToken cancellationToken)
        {
            var createdCategory = await _categoryService.CreateCategoryAsync(newCategory, cancellationToken);

            return Ok(createdCategory);
        }

        [HttpGet]
        [SwaggerOperation("Get categories")]
        [ProducesResponseType(typeof(IEnumerable<CategoryDTO>), 200)]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategoriesAsync([FromQuery] PaginationSettingsDTO paginationSettings, CancellationToken cancellationToken)
        {
            var categories = await _categoryService.GetCategoriesAsync(paginationSettings, cancellationToken);

            return Ok(categories);
        }

        [HttpGet("{id}")]
        [SwaggerOperation("Get category by ID")]
        [ProducesResponseType(typeof(CategoryDTO), 200)]
        public async Task<ActionResult<CategoryDTO>> GetCategoryByIdAsync(int id, CancellationToken cancellationToken)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id, cancellationToken);

            return Ok(category);
        }

        [HttpPut("{id}")]
        [SwaggerOperation("Update a category")]
        [ProducesResponseType(typeof(CategoryDTO), 200)]
        public async Task<ActionResult<CategoryDTO>> UpdateCategoryAsync(int id, CategoryDTO categoryDTO, CancellationToken cancellationToken)
        {
            var updatedCategory = await _categoryService.UpdateCategoryAsync(categoryDTO, id, cancellationToken);

            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Delete a category")]
        [ProducesResponseType(typeof((bool, string)), 200)]
        public async Task<ActionResult<(bool, string)>> DeleteCategoryAsync(int id, CancellationToken cancellationToken)
        {
            var result = await _categoryService.DeleteCategoryAsync(id, cancellationToken);

            return Ok(result);
        }
    }
}
