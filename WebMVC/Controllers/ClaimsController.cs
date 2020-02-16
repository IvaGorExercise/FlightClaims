using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.Services;
using WebMVC.ViewModels;

namespace WebMVC.Controllers
{
    public class ClaimsController : Controller
    {

      
        public IActionResult Index()
        {
             return View();
        }

        public IActionResult Canceled()
        {
            var vm = new ClaimViewModel()
            {
                Consequence = "C"
            };

            return View(vm);
        }

        public IActionResult Delayed()
        {
            var vm = new ClaimViewModel()
            {
                Consequence = "D",
                NewFlightNumber = "DD9999",
                NewFlightDate = new DateTime(1, 1, 1)
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult PostClaim(ClaimViewModel model)
        {
            String PostView = "Index";
            try
            {
                //if (ModelState.IsValid)
                //{

                    //var basket = _orderSvc.MapOrderToBasket(model);
                    ClaimService claimService = new ClaimService();
                    claimService.CreateClaim(model);

                    if (model.Consequence.ToUpper().Equals("C"))
                    {
                        PostView = "Canceled";
                    }
                    else
                    {
                        PostView = "Delayed";
                    }
                //}
            }
            catch (Exception ex)
            {
                PostView = "Index";
                ModelState.AddModelError("Error", $"It was not possible to create a new order, please try later on ({ex.GetType().Name} - {ex.Message})");
            }

              return View(PostView, model);
            
        }

    }
}