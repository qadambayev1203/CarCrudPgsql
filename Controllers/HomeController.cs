using CarCrudPgsql.Data;
using CarCrudPgsql.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarCrudPgsql.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ICarRepository _repository;

        public HomeController(ILogger<HomeController> logger, ICarRepository carRepository)
        {
            _logger = logger;
            _repository = carRepository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Car> cars = _repository.GetAll();

            return View(cars);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Car car = _repository.GetById(id);

            return View(car);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car car)
        {
            if (car != null)
            {
                _repository.Create(car);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Car car = _repository.GetById(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult Update(Car car)
        {
            if (car != null)
            {
                _repository.Update(car);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Car car = _repository.GetById(id);
            return View(car);
        }

        [HttpPost]
        public IActionResult Delete(Car car)
        {
            _repository.Delete(car);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
