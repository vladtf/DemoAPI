using DemoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebAPI.Controllers
{
    /// <summary>
    /// This is where I give you all the info about people.
    /// </summary>
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            //people.Add(new Person { FirstName = "Tim", LastName = "Corey", Id = 1 });
            //people.Add(new Person { FirstName = "Sue", LastName = "Storm", Id = 2 });
            //people.Add(new Person { FirstName = "Audrey", LastName = "Jenkins", Id = 3 });
            //people.Add(new Person { FirstName = "Billy", LastName = "Peterson", Id = 4 });
            //people.Add(new Person { FirstName = "John", LastName = "Johnson", Id = 5 });
            //people.Add(new Person { FirstName = "George", LastName = "Wisley", Id = 6 });
            //people.Add(new Person { FirstName = "Alex", LastName = "Granger", Id = 7 });
            //people.Add(new Person { FirstName = "Stan", LastName = "Potter", Id = 8 });
            //people.Add(new Person { FirstName = "Stewy", LastName = "Baggings", Id = 9 });

            people = SQLServerConnection.GetPeople();
        }


        /// <summary>
        /// Gets a list of the first name of all users.
        /// </summary>
        /// <param name="userId">The unique identifier for this person</param>
        /// <param name="age">We wand to know how old they are</param>
        /// <returns>A list of first names...</returns>
        [Route("api/People/GetFirsNames/{userID:int}/{age:int}")]
        [HttpGet]
        public List<string> GetFirstNames(int userId, int age)
        {
            List<string> output = new List<string>();
            foreach (var p in people)
            {
                if(p.Id>userId)
                output.Add(p.first_name);

            }
            return output;
        }


        /// <summary>
        /// Gets the people with specified last name.
        /// </summary>
        /// <param name="last_name"></param>
        /// <returns></returns>
        [Route("api/People/{lastname}")]
        [HttpGet]
        public List<Person> GetByLastName(string lastname)
        {
            List<Person> output = new List<Person>();
            foreach (var p in people)
            {
                if (p.last_name == lastname)
                    output.Add(p);

            }
            return output;
        }


        // GET: api/People
        public List<Person> Get()
        {
            return people;
        }

        // GET: api/People/5
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST: api/People
        public void Post(Person val)
        {
            people.Add(val);
        }
        
        // DELETE: api/People/5
        public void Delete(int id)
        {
        }
    }
}
