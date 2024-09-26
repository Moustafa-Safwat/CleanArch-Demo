using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<CourseDto>> GetCources()
        {
            return courseService.GetPaged(1, 10).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourseDto>> GetCourseById(int id)
        {
            var course = await courseService.GetByIdAsync(id);
            if (course is null)
            {
                return NotFound();
            }
            return course;
        }

        [HttpPost]
        public async Task<ActionResult> Add(CourseDto courseDto)
        {
            var result = await courseService.AddAsync(courseDto);
            if (result != -1)
            {
                return CreatedAtAction(nameof(GetCourseById),
                    new { Id = result },
                    new { Message = "Created successfully" });
            }
            return BadRequest();
        }

        [HttpGet("{courseId}/students")]
        public ActionResult<List<HumanDto>> GetStudentsFromCourse(int courseId)
        {
            var students = courseService.GetStudentFromCourseId(courseId).ToList();
            if (students.Count == 0)
            {
                return NotFound();
            }
            return students;
        }
    }
}
