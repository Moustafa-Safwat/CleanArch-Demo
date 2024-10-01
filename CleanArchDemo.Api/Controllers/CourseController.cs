using CleanArchDemo.Application.Commands.CourseCommand;
using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Reflection;

namespace CleanArchDemo.Api.Controllers
{
    [Route("api/[controller]")]
    public class CourseController(ISender sender, ICourseService courseService) : ApiController(sender)
    {
        // GET : api/course?pageNumber=1&pageSize=10
        [HttpGet]
        public ActionResult GetCourses(int pageNumber, int pageSize)
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
            return Ok(Result<IEnumerable<CourseDto>>.Create(courses));
        }

        // GET : api/course/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCourseById(int id,CancellationToken cancellationToken)
        {
            Result<CourseDto> response = await courseService.GetByIdAsync(id,cancellationToken);
            if (response.IsFailure)
            {
                return NotFound(new Error("Course.NotFound",
                    $"Course with Id [{id}], is not found in the database"));
            }
            return Ok(response.Value);
        }

        // POST : api/course
        [HttpPost]
        public async Task<ActionResult> Add(CourseDto courseDto, CancellationToken cancellationToken)
        {
            var result = await Sender.Send(new CreateCourseCommand(
                        courseDto.Name,
                        courseDto.Code,
                        courseDto.Credits,
                        courseDto.Description,
                        courseDto.DepartmentId), cancellationToken);
            //var result = await courseService.AddAsync(courseDto);
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetCourseById),
                    new { Id = result.Value },
                    result);
            }
            return BadRequest(result.Error);
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
