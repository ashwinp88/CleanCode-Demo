using System;

namespace AwesomeApplication.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public void AssignTask(Task task)
        {
            if (task.StartDate.Ticks >= StartDate.Ticks && task.EndDate.Ticks <= EndDate.Ticks)
            {
                task.AssignedPerson = this;
            }
            else
            {
                throw new ApplicationException("Person is unavailable for the task.");
            }
        }
    }
}
