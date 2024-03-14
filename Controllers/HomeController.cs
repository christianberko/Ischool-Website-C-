using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Dynamic;
using WebApp2.Models;
using WebApp2.Models.Services;

namespace WebApp2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task <ActionResult> People()
        {
			DataRetrieval dataR = new DataRetrieval();
			var loadedPep = await dataR.GetData("people/");

			var rtnResult = JsonConvert.DeserializeObject<PeopleModel>(loadedPep);
			return View(rtnResult);
			
        }

        public async Task <IActionResult> About()
        {
            //build model
            //go and get data
            //turn data into JSON
            //add more data to Model
            //end the model to the View

            DataRetrieval dataR = new DataRetrieval();
            var loadedAbt = await dataR.GetData("about/");

            var rtnResult = JsonConvert.DeserializeObject<AboutModel>(loadedAbt);
            return View(rtnResult);
        }


        
        public async Task <IActionResult> Degrees()
        {
            var dataR = new DataRetrieval();
            var loadedDeg = await dataR.GetData("degrees/");

            var rtnResult = JsonConvert.DeserializeObject<DegreeModel>(loadedDeg);
            return View(rtnResult);
        }


        public async Task<IActionResult> Minors()
        {
            var dataR = new DataRetrieval();
            var loadedMin= await dataR.GetData("minors/");

            var rtnResult = JsonConvert.DeserializeObject<MinorsModel>(loadedMin);
            return View(rtnResult);
        }


        public async Task<IActionResult> MinorsCourses()
        {
            //getting minors 
            var dataR = new DataRetrieval();
            var loadedMin = await dataR.GetData("minors/");

            var rtnResult = JsonConvert.DeserializeObject<MinorsModel>(loadedMin);
            
            //getting courses 
            var loadedCourse = await dataR.GetData("course/");
            var courseResult = JsonConvert.DeserializeObject<CourseModel>(loadedCourse);

            //creating expando obj
            dynamic expando = new ExpandoObject();
            var comboModel = expando as IDictionary<string, object>;

            comboModel.Add("Minor", rtnResult);
            comboModel.Add("Course", courseResult);

            return View(comboModel);
        }
        
        public async Task<IActionResult> Course()
        {
			var dataR = new DataRetrieval();
			var loadedCourse = await dataR.GetData("course/");

			var rtnResult = JsonConvert.DeserializeObject<MinorsModel>(loadedCourse);
			return View(rtnResult);
		}

        public async Task<IActionResult> Employment()
        {
            var dataR = new DataRetrieval();
            var loadedEmp = await dataR.GetData("employment/");

            var rtnResult = JsonConvert.DeserializeObject<EmploymentModel>(loadedEmp);
            return View(rtnResult);
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}