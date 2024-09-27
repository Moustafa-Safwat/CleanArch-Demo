using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        // GET : api/course
        [HttpGet]
        public ActionResult<List<CourseDto>> GetCources()
        {
            return courseService.GetPaged(1, 10).ToList();
        }

        // GET : api/course/{id}
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

        // POST : api/course
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

        // GET : api/course/{courseId}/students
        [HttpGet("{courseId}/students")]
        public ActionResult<List<HumanDto>> GetStudentsFromCourse(int courseId)
        {
            var students = courseService.GetStudentFromCourseId(courseId);
            if (!students.Any())
            {
                return NotFound();
            }
            return students.ToList();
        }

    }
}
