using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Core.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService courseService) : ControllerBase
    {
        // GET : api/course?pageNumber=1&pageSize=10
        [HttpGet]
        public ActionResult<List<CourseDto>> GetCourses(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }
            var courses = courseService.GetPaged(pageNumber, pageSize);
            if (!courses.Any())
            {
                return NotFound("No courses found.");
            }
            return courses.ToList();
        }

        // GET : api/course/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCourseById(int id)
        {
            ResultT<CourseDto> response = await courseService.GetByIdAsync(id);
            if (response.IsFailure)
            {
                return NotFound(new Error("Course.NotFound",
                    $"Course with Id [{id}], is not found in the database"));
            }
            return Ok(response.Value);
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

        // UPDATE : api/course/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(int id, CourseDto courseDto)
        {
            if (id != courseDto.Id)
            {
                return BadRequest("ID mismatch.");
            }
            var (Success, Message) = await courseService.UpdateAsync(courseDto);
            if (Success)
            {
                return Ok(Message);
            }
            return BadRequest(Message);
        }

        // DELETE : api/course/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var (Success, Message) = await courseService.DeleteAsync(id);
            if (Success)
            {
                return Ok(Message);
            }
            return BadRequest(Message);
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
