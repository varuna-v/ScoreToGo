using STGBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScoreToGo.Controllers
{
    public class RotationController : Controller
    {
        public ActionResult Index()
        {
            var model = new RotationModel()
            {
                ShirtNumbers = new int[] { 5, 12, 6, 7, 10, 1 }
            };
            return View(model);
        }
        
        public ActionResult Rotate(RotationModel model)
        {
            model.Rotate();
            return View("Index", model);
        }
    }
}