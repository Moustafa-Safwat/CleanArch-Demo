using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchDemo.Api.Controllers
{
    [ApiController]
    public class ApiController (ISender sender) : ControllerBase
    {
        protected ISender Sender => sender;
    }
}
