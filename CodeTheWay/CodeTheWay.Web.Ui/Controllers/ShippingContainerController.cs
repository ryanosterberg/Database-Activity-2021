using CodeTheWay.Web.Ui.Models;
using CodeTheWay.Web.Ui.Models.ViewModels;
using CodeTheWay.Web.Ui.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeTheWay.Web.Ui.Controllers
{
    public class ShippingContainerController : Controller
    {
        private IShippingContainerService ShippingContainerService;

        public ShippingContainerController(IShippingContainerService shippingContainerService)
        {
            this.ShippingContainerService = shippingContainerService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await ShippingContainerService.GetStudents());
        }

        public async Task<IActionResult> Create()
        {
            return View(new ShippingContainerRegistrationViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(ShippingContainerRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ShippingContainer box = new ShippingContainer()
                {
                    Id = model.Id,
                    Weight = model.Weight,
                    Destination = model.Destination
                };
                var result = await ShippingContainerService.Create(box);
                return RedirectToAction("Index");  //Success!!
            }
            else
            {
                return RedirectToAction("Index");  //This should take us to an age error view
            }

            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            ShippingContainer result = await ShippingContainerService.GetShippingCcontainer(id);
            ShippingContainerRegistrationViewModel box = new ShippingContainerRegistrationViewModel()
            {
                Id = result.Id,
                Weight = result.Weight,
                Destination = result.Destination
            };
            return View(box);
        }
        [HttpPost]
        public async Task<IActionResult> UpDate(ShippingContainerRegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ShippingContainer box = new ShippingContainer()
                {
                    Id = model.Id,
                    Weight = model.Weight,
                    Destination = model.Destination
                };
                ShippingContainer result = await ShippingContainerService.Update(box);
                return RedirectToAction("Index"); //Success
            }
            else
            {
                return RedirectToAction("Index");  //This should take us to an age error view
            }
            return View(model);
        }
        public async Task<IActionResult> Details(Guid id)
        {
            ShippingContainer result = await ShippingContainerService.GetShippingContainer(id);
            ShippingContainerRegistrationViewModel box = new ShippingContainerRegistrationViewModel()
            {
                Id = result.Id,
                Weight = result.Weight,
                Destination = result.Destination,
            };
            return View(box);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var box = await ShippingContainerService.GetShippingContainer(id);
            await ShippingContainerService.Delete(box);
            return RedirectToAction("Index");
        }
    }
}
