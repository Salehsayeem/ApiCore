using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApiContext _db;
        public StudentsController(ApiContext db)
        {
            _db = db;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _db.Students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}",Name ="Get")]
        public Student Get(int id)
        {
            return _db.Students.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student student)
        {
            _db.Students.Update(student);
            _db.SaveChanges();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _db.Students.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _db.Students.Remove(item);
                _db.SaveChanges();
            }
        }
    }
}
