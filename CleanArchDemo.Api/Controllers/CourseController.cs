using CleanArchDemo.Application.Commands.CourseCommand;
using CleanArchDemo.Application.Dtos;
using CleanArchDemo.Application.Interfaces;
using CleanArchDemo.Application.Queries;
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
        public async Task<ActionResult> GetCourseById(int id, CancellationToken cancellationToken)
        {
            // Implement the CQRS in this end point
            var result =await Sender.Send(new GetCourseByIdQuery(id), cancellationToken);
            //Result<CourseDto> response = await courseService.GetByIdAsync(id, cancellationToken);
            if (result.IsFailure)
            {
                return NotFound(result);
            }
            return Ok(result);
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
                    Response<int>.Create(result,Core.Shared.StatusCode.Created));
            }
            return BadRequest(result);
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
            var result = await Sender.Send(new DeleteCourseCommand(id));
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
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
