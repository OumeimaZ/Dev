using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevOps.Controllers
{
    public class ValuesController : ApiController
    {


        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        public int multiplication (int a ,int b)
        {

            int mul = a * b;
            return mul;

        }
        public double BMI(double weight, double height)
        {
            if (height >= 0)
            {
                double BMI = weight / Math.Pow(height, 2);

                return BMI;
            } 
            else return 0;
        }

    }
}
