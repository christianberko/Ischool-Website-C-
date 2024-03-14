using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Net.Http.Headers;
namespace WebApp2.Models.Services
{
    public class DataRetrieval

    {
        /* 
         Task vs Thread
        Task has async/await and can return a value
        Task can do multiple thig sa to nc, thread can do oe 
        can cancel a task
        task is a higher level concept than a thread (if we were more cs it mean that a task is based off a thread meaning that is slower) 
         */
        // use - getData("about/")
        public async Task<string> GetData(string endpoint)
        {
            //using = at the end of the statement it is automatically disposed of.
            using(var client = new HttpClient())
            {
                //set up base
                client.BaseAddress = new Uri("https://ischool.gccis.rit.edu/api/");
                //clean it up
                client.DefaultRequestHeaders.Accept.Clear();
                //set the type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicaiton/json"));

                try
                {
                    //get ready to sendoff
                    HttpResponseMessage response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);  
                    response.EnsureSuccessStatusCode();
                    //goin to get DATA.....
                    var data = await response.Content.ReadAsStringAsync();
                    return data;

                }
                catch(HttpRequestException hre) 
                {
                    var msg = hre.Message;
                    return "HttpRequest: " + msg;
                }

                catch (Exception e)
                {
                    var msg = e.Message;
                    return "Ex: " + msg;
                }
            }

        }

    }
}
