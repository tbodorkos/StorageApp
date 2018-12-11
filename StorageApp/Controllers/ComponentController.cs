using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Interfaces;

namespace StorageApp.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IComponentService _componentService;

        public ComponentController(IComponentService componentService)
        {
            _componentService = componentService;
        }

        public async Task<IActionResult> Index()
        {
            var components = await _componentService.GetAllAsync();

            return View(components);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Component model)
        {
            try
            {
                await _componentService.CreateAsync(model.Name, model.Price, model.Description, model.Weight);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var component = await _componentService.GetByIdAsync(id);

            return View(component);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Component model)
        {
            try
            {
                await _componentService.EditAsync(model.Id, model.Name, model.Price, model.Description, model.Weight);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _componentService.DeleteAsync(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
