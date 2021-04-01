using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


namespace WebApplication5.Controllers
{

    [ApiController]
    [Route("instagram")] //маршут
    public class Instagram : Controller
    {
        private readonly ISearch _search;

        public Instagram(ISearch search)
        {
            _search = search;
        }

        [HttpGet("home")]
        public string Home(string name)
        {
            return $"Новости за сьоодні {name}";
        }

        [HttpGet("search")]
        public string Search(string name)
        {
            var a = _search.Search(name);
            return a.ToString();
        }

        [HttpPost("add-user")]
        public void AddUser(string name, string surname)
        {
            User user = new User(name, surname);
            user.WriteDown();
        }

        [HttpGet("user")]
        public string UserInformat()
        {
            User user = new User();

            return user.Print().Result;
        }
    }
    public class User
    {
        public string name { get; set; } = "Costel";
        public string surname { get; set; } = "Swagger";

        public User()
        {

        }

        public User(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public void WriteDown()
        {
            string objSerial = JsonSerializer.Serialize(this);
            File.WriteAllText("User.json", objSerial);
        }       

        public async Task<string> Print()
        {
            using (FileStream fs = new FileStream("User.json", FileMode.OpenOrCreate))
            {
                User restoredPerson = await JsonSerializer.DeserializeAsync<User>(fs);
                return $"Name: {restoredPerson.name}  Age: {restoredPerson.surname}";
            }
        }
    }
}
