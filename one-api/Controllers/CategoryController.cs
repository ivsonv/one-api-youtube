using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace one_api.Controllers
{
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly Infra.AdminContext _context;

        public CategoryController(Infra.AdminContext context)
        {
            _context = context;
        }

        [HttpGet] // leitura
        public IActionResult Index()
        {
            var list = _context.Categories
                .Select(category => new Domain.DTO.Category.CategoryItem()
                {
                    id = category.id,
                    name = category.name,
                    active = category.active
                }).AsNoTracking().ToList();

            return Ok(list);
        }

        [HttpPost] // criação
        public void Store([FromBody] Domain.DTO.Category.CategoryItem _request)
        {
            _context.Categories.Add(new Domain.Entities.Category()
            {
                name = _request.name,
                active = _request.active
            });

            _context.SaveChanges();
        }

        [HttpPut] // atualização de registro
        public IActionResult Update([FromBody] Domain.DTO.Category.CategoryItem _request)
        {
            if (_request.id <= 0)
                return BadRequest("Informe o Id para atualização");

            var entity = new Domain.Entities.Category()
            {
                name = _request.name,
                active = _request.active,
                id = _request.id
            };

            _context.Categories.Update(entity);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id:int}")] // delete for tupla
        public IActionResult Delete([FromRoute] int id)
        {
            var entity = _context.Categories.FirstOrDefault(f => f.id == id);

            if (entity == null)
                return NotFound();

            _context.Categories.Remove(entity);

            _context.SaveChanges();

            return NoContent();
        }

    }
}
