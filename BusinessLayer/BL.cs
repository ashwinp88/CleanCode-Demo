using Shared;
using System.Collections.Generic;

namespace AwesomeApplication
{
    public class BL
    {

        public BL()
        {
            _reader = new WebServiceReader();
            RefreshPeople();
        }
        public IEnumerable<Person> People { get; private set; }

        protected WebServiceReader _reader;

        public void RefreshPeople()
        {
            People = _reader.GetPeople();
        }

        public void ClearPeople()
        {
            People = new List<Person>();
        }
    }
}
