using Newtonsoft.Json;
using Shared;
using System.Collections.Generic;
using System.Net.Http;

namespace AwesomeApplication
{
    public class WebServiceReader 
    {
        HttpClient webClient = new HttpClient();
        string baseUri = "http://localhost:5000/api/people";
        public IEnumerable<Person> GetPeople()
        {
            IEnumerable<Person> ret = null;
            string result = webClient.GetStringAsync(baseUri).Result;
            ret = JsonConvert.DeserializeObject<IEnumerable<Person>>(result);
            return ret;
        }

        public Person GetPerson(int id)
        {
            string result = webClient.GetStringAsync($"{baseUri}/{id}").Result;
            var ret = JsonConvert.DeserializeObject<Person>(result);
            return ret;
        }
    }
}
