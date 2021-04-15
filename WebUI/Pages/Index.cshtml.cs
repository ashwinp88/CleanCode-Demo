using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeApplication.Domain;

namespace WebUI.Pages
{
    public class PeopleModel : PageModel
    {
        private readonly ILogger<PeopleModel> _logger;

        public readonly IList<Person> People;

        public PeopleModel(ILogger<PeopleModel> logger)
        {
            _logger = logger;
            var webDataService = new AwesomeApplication.DataAccess.WebDataService("http://localhost:5000/api");
            var businessLogic = new AwesomeApplication.BL.BL(webDataService);

            People = businessLogic.GetPeople();
        }

        public void OnGet()
        {

        }
    }
}
