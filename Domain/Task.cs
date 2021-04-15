using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeApplication.Domain
{
    public class Task
    {
        public int Id { get; set; }
        public string Descrption { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Person AssignedPerson { get; set; }
    }
}
