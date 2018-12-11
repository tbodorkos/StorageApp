using System;
using System.Linq;
using StorageApp.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Core.Interfaces;

namespace StorageApp.Controllers
{
    public class StorageController : Controller
    {
        private readonly IStorageService _storageService;
        private readonly IComponentService _componentService;

        public StorageController(IStorageService storageService, IComponentService componentService)
        {
            _storageService = storageService;
            _componentService = componentService;
        }

        public async Task<IActionResult> Index(StorageViewModel model = null)
        {
            if (model == null)
            {
                model = new StorageViewModel();
            }
            model.Items = await _storageService.GetAllAsync();
            model.Components = await _componentService.GetAllAsync();
            model.IsAdd = false;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrRemove(StorageViewModel model)
        {
            try
            {
                if (model.ComponentId == Guid.Empty)
                {
                    throw new InvalidOperationException("Először válasszon ki egy terméket!");
                }

                if (model.IsAdd)
                {
                    await _storageService.AddAsync(model.ComponentId, model.Piece);
                }
                else
                {
                    await _storageService.RemoveAsync(model.ComponentId, model.Piece);
                }

                return RedirectToAction(nameof(Index));
            }
            catch(InvalidOperationException e)
            {
                model.Errors = new List<string>() { e.Message };
                return RedirectToAction(nameof(Index), model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Statistics()
        {
            var storage = await _storageService.GetAllAsync();
            var components = await _componentService.GetAllAsync();
            if(storage == null || storage.Count() == 0)
            {
                return View(null);
            }

            var model = new StatisticsViewModel();
            model.StorageValue = storage.Sum(s => s.Component.Price * s.Piece);
            model.StorageWeight = storage.Sum(s => s.Component.Weight * s.Piece);
            model.PieceComponent = storage.OrderByDescending(s => s.Piece).FirstOrDefault()?.Component;
            model.WeightComponent = storage.OrderByDescending(s => s.Component.Weight).FirstOrDefault()?.Component;

            return View(model);
        }
    }
}