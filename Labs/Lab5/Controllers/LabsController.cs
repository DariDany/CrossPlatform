using System.Diagnostics;
using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using LabsLibrary;

namespace Lab5.Controllers
{
    public class LabsController : Controller
    {
        //[Authorize]
        [HttpGet]
        public IActionResult FindLength()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FindLength(IFormFile inputFile)
        {
            if (inputFile == null || inputFile.Length == 0)
            {
                ViewBag.Result = "Будь ласка, завантажте файл.";
                return View();
            }
            string inputFilePath = Path.Combine(Path.GetTempPath(), inputFile.FileName);
            using (var stream = new FileStream(inputFilePath, FileMode.Create))
            {
                inputFile.CopyTo(stream);
            }
            string outputFilePath = Path.Combine(Path.GetTempPath(), "output.txt");
            LabRunner labRunner = new LabRunner();
            labRunner.RunLab1(inputFilePath, outputFilePath);
            string result = System.IO.File.ReadAllText(outputFilePath);
            ViewBag.Result = result;

            return View();
        }

        //[Authorize]
        [HttpGet]
        public IActionResult EntCounter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EntCounter(IFormFile inputFile)
        {
            if (inputFile == null || inputFile.Length == 0)
            {
                ViewBag.Result = "Будь ласка, завантажте файл.";
                return View();
            }
            string inputFilePath = Path.Combine(Path.GetTempPath(), inputFile.FileName);
            using (var stream = new FileStream(inputFilePath, FileMode.Create))
            {
                inputFile.CopyTo(stream);
            }
            string outputFilePath = Path.Combine(Path.GetTempPath(), "output.txt");
            LabRunner labRunner = new LabRunner();
            labRunner.RunLab2(inputFilePath, outputFilePath);
            string result = System.IO.File.ReadAllText(outputFilePath);
            ViewBag.Result = result;

            return View();
        }

        //[Authorize]
        [HttpGet]
        public IActionResult RectangleAreaSolver()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RectangleAreaSolver(IFormFile inputFile)
        {
            if (inputFile == null || inputFile.Length == 0)
            {
                ViewBag.Result = "Будь ласка, завантажте файл.";
                return View();
            }
            string inputFilePath = Path.Combine(Path.GetTempPath(), inputFile.FileName);
            using (var stream = new FileStream(inputFilePath, FileMode.Create))
            {
                inputFile.CopyTo(stream);
            }
            string outputFilePath = Path.Combine(Path.GetTempPath(), "output.txt");
            LabRunner labRunner = new LabRunner();
            labRunner.RunLab3(inputFilePath, outputFilePath);
            string result = System.IO.File.ReadAllText(outputFilePath);
            ViewBag.Result = result;

            return View();
        }
    }
}
