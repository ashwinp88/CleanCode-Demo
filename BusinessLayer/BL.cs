using AwesomeApplication.Domain;
using System.Collections.Generic;

namespace AwesomeApplication.BL
{
    public class BL
    {
        private IDataService _dataService;

        public BL(IDataService dataService)
        {
            _dataService = dataService;
        }

        public IList<Person> GetPeople()
        {
            return _dataService.GetPeople();
            // call additional infrastructure code for example, notify payroll
        }

        public IList<Task> GetTasks()
        {
            return _dataService.GetTasks();
        }

        public Person GetPerson(int Id)
        {
            return _dataService.GetPerson(Id);
        }

        public Task GetTask(int Id)
        {
            return _dataService.GetTask(Id);
        }

        public int CreateOrUpdateTask(Task task)
        {
            return _dataService.CreateOrUpdateTask(task);
        }
    }

    public interface IDataService
    {
        IList<Person> GetPeople();
        IList<Task> GetTasks();
        Person GetPerson(int Id);
        Task GetTask(int Id);
        int CreateOrUpdateTask(Task task);
    }
}
