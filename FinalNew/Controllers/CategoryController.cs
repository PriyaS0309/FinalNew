using FinalNew.Models;
using FinalNew.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryRepo _categoryRepo;

        public CategoryController(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<ActionResult>GetCategories()
        {
            return Ok(await _categoryRepo.GetCategories());
        }

        [HttpGet("{id:int}")]

        public async Task<ActionResult>GetCategoryId(int id)
        {
            return Ok(await _categoryRepo.GetCategoryByID(id));
        }

        [HttpGet("{name}")]

        public async Task<ActionResult> GetCategoryName(string name)
        {
            return Ok(await _categoryRepo.GetCategoryByName(name));
        }

        [HttpPost]

        public async Task<ActionResult<Category>>CreateCategory(Category category)
        {
            var CreatedCategory = await _categoryRepo.CreateCategory(category);


            return CreatedAtAction(nameof(GetCategoryId), new { id = CreatedCategory.CategoryID }, CreatedCategory);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Category>>EditCategory(int id,Category category)
        {
            var updatedDepartment = await _categoryRepo.GetCategoryByID(id);

            return await _categoryRepo.EditCategory(category);
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<Category>>DeleteCategory(int id)
        {
            var deletedcegory = await _categoryRepo.GetCategoryByID(id);
            return await _categoryRepo.DeleteCategory(id);
        }


    }
}
