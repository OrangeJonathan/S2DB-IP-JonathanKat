using DemoMultilayerArchitecture.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoMultilayerArchitecture.Controllers
{
    public class HomeController : Controller
    {
        private IBusinessLayer _businessLayer;

        public HomeController()
        {
            _businessLayer = new BusinessLayer.BusinessLayer(new DataLayer.DataLayer());
        }

        public ActionResult Index()
        {
            var model = _businessLayer.GetProducts();
            return View(model);
        }
    }
}