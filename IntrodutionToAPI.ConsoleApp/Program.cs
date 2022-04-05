using System;
// below uses collection things such as lists
using System.Collections.Generic;
// below allows us to work with SQL-like commands
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntrodutionToAPI.ConsoleApp.Models;
using Newtonsoft.Json;

namespace IntrodutionToAPI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient httpClient = new HttpClient();

            // for below, need to be wary of asynchronous & synchronous
            HttpResponseMessage response = httpClient.GetAsync("https://swapi.dev/api/people/1").Result;

            if (response.IsSuccessStatusCode)
            {
                // var below is a string; you can tell by hovering over the var as well as the ReadAsStringAsync()
                var content = response.Content.ReadAsStringAsync().Result;
                var person = JsonConvert.DeserializeObject<Person>(content);

                // the below line is a combo replacement of the above two lines
                Person luke = response.Content.ReadAsAsync<Person>().Result;
                Console.WriteLine(luke.Name);

                // to get vehicles
                foreach (string vehiclesUrl in luke.Vehicles)
                {
                    // at this point: would need to convert vehicle JSON, create a vehicles class, and repeat the same process as with the person
                }
            }
        }
    }
}