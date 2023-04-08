using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProjeOT.Data;
using WebProjeOT.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebProjeOT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ApplicationDbContext k;

        public CategoriesApiController(ApplicationDbContext nesne)
        {
            k = nesne;
        }
        // GET: api/<CategoriesApiController>
        [HttpGet]
        public List<Categories> Get()
        {
            return k.CategorieS.ToList();
        }

        // GET api/<CategoriesApiController>/5
        [HttpGet("{id}")]
        public Categories Get(int id)
        {
            var y = k.CategorieS.FirstOrDefault(x => x.CategoriesID == id);
            return y;
        }

        // POST api/<CategoriesApiController>
        [HttpPost]
        public void Post([FromBody] Categories y)
        {
            k.CategorieS.Add(y);
            k.SaveChanges();
        }

        // PUT api/<CategoriesApiController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Categories y)
        {
            var y1 = k.CategorieS.FirstOrDefault(x => x.CategoriesID == id);

            if (y1 is null)
            {
                return NotFound();
            }
            else 
            {
                y1.CategoriesName = y.CategoriesName;
                y1.CategoryDescription = y.CategoryDescription;
                k.Update(y1);
                k.SaveChanges();
                return Ok();
            }
        }

        // DELETE api/<CategoriesApiController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var y1 = k.CategorieS.FirstOrDefault(s => s.CategoriesID == id);

            if (y1 is null)
            {
                return NotFound();
            }
            else
            {
                k.Remove(y1);
                k.SaveChanges();
                return Ok();
            }
        }
    }
}
