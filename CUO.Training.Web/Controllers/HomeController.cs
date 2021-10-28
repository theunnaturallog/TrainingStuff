using Cuo.Training.Web.MathApiProxy;
using CUO.Training.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUO.Training.Web.Controllers
{

    public class HomeController : Controller
    {
        private string baseURL = "https://localhost:44372";
        
        public ActionResult Index(decimal x = 0, decimal y = 0)
        {
            var mathModel = new MathOperationModel();
            return View(mathModel);
        }
        [HttpPost]
        public ActionResult Index(MathOperationModel MathModel)
        {
            ViewBag.X = MathModel.X;
            ViewBag.Y = MathModel.Y;
            decimal x = MathModel.X;
            decimal y = MathModel.Y;
            int mathOp = ((int)MathModel.MyOperation);
            if (mathOp == 0) { Add(x, y); }
            else if (mathOp == 1) { Subtract(x, y); }
            else if (mathOp ==2) { Multiply(x, y); }
            else if (mathOp == 3) { Divide(x, y); }

            return View();
        }

        public ActionResult Add(decimal x = 1, decimal y = 2)
        {
            var requestUrl = baseURL + "/Math/Add";
            var request = new AddRequest()
            {
                X = x,
                Y = y
            };
            var ReqString = JsonConvert.SerializeObject(request);


            var mathClient = new MathApiClient();
            var responseString = mathClient.DoPost(requestUrl, ReqString);
            var response = JsonConvert.DeserializeObject<AddResponse>(responseString);
            ViewBag.X = response.X;
            ViewBag.Y = response.Y;
            ViewBag.Result = response.Result;
            return View("Index");
        }

        public ActionResult Subtract(decimal x = 2, decimal y = 1)
        {
            var requestUrl = baseURL + "/Math/Subtract";
            var request = new SubtractRequest()
            {
                X = x,
                Y = y
            };

            var requestString = JsonConvert.SerializeObject(request);
            var mathClient = new MathApiClient();
            var responseString = mathClient.DoPost(requestUrl, requestString);
            var response = JsonConvert.DeserializeObject<SubtractResponse>(responseString);

            ViewBag.X = response.X;
            ViewBag.Y = response.Y;
            ViewBag.Result = response.Result;
            return View("Index");
        }

        public ActionResult Multiply(decimal x = 2, decimal y = 1)
        {
            var requestUrl = baseURL + "/Math/Multiply";
            var request = new MultiplyRequest()
            {
                X = x,
                Y = y
            };

            var requestString = JsonConvert.SerializeObject(request);
            var mathClient = new MathApiClient();
            var responseString = mathClient.DoPost(requestUrl, requestString);
            var response = JsonConvert.DeserializeObject<MultiplyResponse>(responseString);

            ViewBag.X = response.X;
            ViewBag.Y = response.Y;
            ViewBag.Result = response.Result;
            return View("Index");
        }

        public ActionResult Divide(decimal x = 2, decimal y = 1)
        {
            var requestUrl = baseURL + "/Math/Divide";
            var request = new DivideRequest()
            {
                X = x,
                Y = y
            };

            var requestString = JsonConvert.SerializeObject(request);
            var mathClient = new MathApiClient();
            var responseString = mathClient.DoPost(requestUrl, requestString);
            var response = JsonConvert.DeserializeObject<DivideResponse>(responseString);

            ViewBag.X = response.X;
            ViewBag.Y = response.Y;
            ViewBag.Result = response.Result;
            return View("Index");
        }

        public ActionResult Calculate(MathOperationModel mathModel)
        {

            return View();

        }

    }
}