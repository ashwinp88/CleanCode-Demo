using AwesomeApplication.BL;
using AwesomeApplication.Domain;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace AwesomeApplication.DataAccess
{
    public class WebDataService : IDataService 
    {
        HttpClient webClient = new HttpClient();
        private string _baseUri;

        public WebDataService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public int CreateOrUpdateTask(Task task)
        {
            string content = JsonConvert.SerializeObject(task);
            var responseMessage = webClient.PutAsync($"{_baseUri}/task", new StringContent(content)).Result;
            int.TryParse(responseMessage.Content.ReadAsStringAsync().Result, out var ret);
            return ret;
        }

        public IList<Person> GetPeople()
        {
            string result = webClient.GetStringAsync($"{_baseUri}/people").Result;
            IList<Person> ret = JsonConvert.DeserializeObject<IList<Person>>(result);
            return ret;
        }

        public Person GetPerson(int id)
        {
            string result = webClient.GetStringAsync($"{_baseUri}/people/{id}").Result;
            var ret = JsonConvert.DeserializeObject<Person>(result);
            return ret;
        }

        public Task GetTask(int id)
        {
            string result = webClient.GetStringAsync($"{_baseUri}/task/{id}").Result;
            var ret = JsonConvert.DeserializeObject<Task>(result);
            return ret;
        }

        public IList<Task> GetTasks()
        {
            IList<Task> ret = null;
            string result = webClient.GetStringAsync($"{_baseUri}/tasks").Result;
            ret = JsonConvert.DeserializeObject<IList<Task>>(result);
            return ret;
        }
    }
}
