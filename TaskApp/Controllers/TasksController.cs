using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskApp.Models;

namespace TaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskAppContext _appContext;
        public TasksController(TaskAppContext appContext)
        {
            _appContext = appContext;
        }


        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List()
        {
            List<Tasks> list = _appContext.Tasks.OrderByDescending(t => t.IdTask).ThenBy(t => t.RegisterDate).ToList();

            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Save([FromBody] Tasks request)
        {
            await _appContext.Tasks.AddAsync(request);
            await _appContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("EndTask/{id:int}")]
        public async Task<IActionResult> EndTask(int id)
        {
            Tasks task = _appContext.Tasks.Find(id);

            _appContext.Tasks.Remove(task);
            await _appContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }


}
