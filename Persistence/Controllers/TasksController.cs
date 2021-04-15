using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Task = AwesomeApplication.Domain.Task;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static IList<Task> _tasks = new List<Task>()
        {
            new Task() {Id = 1, Descrption = "Mission in London", StartDate = new DateTime(2021, 2, 1), EndDate = new System.DateTime(2021, 2, 14)},
            new Task() {Id = 2, Descrption = "Mission in Paris", StartDate = new System.DateTime(2021, 7, 1), EndDate = new System.DateTime(2021, 7, 7)},
            new Task() {Id = 3, Descrption = "Mission in New York", StartDate = new System.DateTime(2021, 10, 1), EndDate = new System.DateTime(2021, 10, 14)}
        };

        [HttpGet]
        public IEnumerable<Task> GetTasks()
        {
            return _tasks;
        }

        [HttpGet("{id}")]
        public Task GetTask(int Id)
        {
            return _tasks.FirstOrDefault(t => t.Id == Id);
        }

        [HttpPut]
        public int InsertOrUpdateTask(Task task)
        {
            if (task.Id == 0)
            {
                task.Id = _tasks.Max(t => t.Id) + 1;
                _tasks.Add(task);
            }
            else
            {
                var taskToBeUpdated = _tasks.Single(t => t.Id == task.Id);
                taskToBeUpdated.Descrption = task.Descrption;
                taskToBeUpdated.StartDate = task.StartDate;
                taskToBeUpdated.EndDate = task.EndDate;
                taskToBeUpdated.AssignedPerson = task.AssignedPerson;
            }
            return task.Id;
        }
    }

   

}
