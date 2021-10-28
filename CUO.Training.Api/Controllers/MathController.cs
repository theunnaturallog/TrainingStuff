using CUO.Training.Api.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CUO.Training.Api.Controllers
{
    public class MathController : Controller
    {
        // GET: Math
        //List the allowed mathematical operations
        //Returns Json Object
        public JsonResult Index()
        {

            //add, subtract, mult, divide
            var operations = new MathOperation[]
            {
                new MathOperation() {OperationName="Add", Description="--", URL=Url.Action("Add", "Math")},
                new MathOperation() {OperationName="Subtract", Description="--", URL=Url.Action("Subtract", "Math")},
                new MathOperation() {OperationName="Multiply", Description="--", URL=Url.Action("Multiply", "Math")},
                new MathOperation() {OperationName="Divide", Description="--", URL=Url.Action("Divide", "Math")}
            };

            //var response = JsonConvert.SerializeObject(operations);

            return Json(operations, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(AddRequest request)
        {
            var result = request.X + request.Y;
            var response = new AddResponse()
            {
                X = request.X,
                Y = request.Y,
                Result = result
            };
            //var responseString = JsonConvert.SerializeObject(response);

            return Json(response);
        }

        [HttpPost]
        public JsonResult Subtract(SubtractRequest request)
        {
            var result = request.X - request.Y;
            var response = new SubtractResponse()
            {
                X = request.X,
                Y = request.Y,
                Result = result
            };
            //var responseString = JsonConvert.SerializeObject(response);

            return Json(response);
        }

        [HttpPost]
        public JsonResult Multiply(MultiplyRequest request)
        {
            var result = request.X * request.Y;
            var response = new MultiplyResponse()
            {
                X = request.X,
                Y = request.Y,
                Result = result
            };
            //var responseString = JsonConvert.SerializeObject(response);

            return Json(response);
        }

        [HttpPost]
        public JsonResult Divide(DivideRequest request)
        {
            decimal result;
            if (request.Y == 0)
            {
                result = 0;
            }

            else { result = request.X / request.Y; }

            var response = new DivideResponse()
            {
                X = request.X,
                Y = request.Y,
                Result = result
            };
            //var responseString = JsonConvert.SerializeObject(response);

            return Json(response);
        }
    }
}