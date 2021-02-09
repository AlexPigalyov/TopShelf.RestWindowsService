using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Web.Http;

namespace TopShelf.RestWindowsService
{
    public class RestController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Ping()
        {
            try
            {
                return Ok(JsonConvert.SerializeObject(DateTime.Now));
            } 
            catch(Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
        [HttpGet]
        public IHttpActionResult Mirror(string jsonString)
        {
            try
            {
                //If the json string is converted, 
                //then the json string is already
                //json and we shouldn't convert it again
                JObject.Parse(jsonString);

                return Ok(jsonString);
            }
            catch
            {
                try
                {
                    //if the string is in the wrong json format
                    //we convert the json string and return it
                    return Ok(JsonConvert.SerializeObject(jsonString));
                }
                catch (Exception exc)
                {
                    //if we caught some error, we return its text
                    return BadRequest(exc.Message);
                }
            }
        }
    }
}
