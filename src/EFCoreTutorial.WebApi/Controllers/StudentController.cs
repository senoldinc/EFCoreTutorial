using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTutorial.Data.Context;
using EFCoreTutorial.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await _applicationDbContext.Students
                                                .Include(st => st.Address)
                                                .ToListAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            var result = await _applicationDbContext.Students.AddAsync(new Student
            {
                FirstName = "John",
                LastName = "Doe",
                Number = 1,
                Address = new StudentAddress(){ City = "LA", Country = "USA", District = "TS", FullAddress = "Xoxoxo sdsdsd"}
            });
            await _applicationDbContext.SaveChangesAsync();
            
            return Ok(result.Entity.Id);
        }
    }
}
