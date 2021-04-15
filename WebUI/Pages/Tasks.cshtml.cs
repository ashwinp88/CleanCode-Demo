using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class TasksModel : PageModel
    {
        public IList<AwesomeApplication.Domain.Task> Tasks;
        public TasksModel()
        {
            var webDataService = new AwesomeApplication.DataAccess.WebDataService("http://localhost:5000/api");
            var businessLogic = new AwesomeApplication.BL.BL(webDataService);

            Tasks = businessLogic.GetTasks();
        }
        public void OnGet()
        {
        }
    }
}
