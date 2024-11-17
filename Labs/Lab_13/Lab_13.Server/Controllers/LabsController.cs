using LabsLibrary;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using Lab_13.Server.Models;

namespace Lab5.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class LabsController : ControllerBase
    {
        
        [HttpGet("lab1")]
        public IActionResult GetLab1()
        {
            var model = new LabViewModel
            {
                LabNumber = 1,
                Title = "Лабораторна робота 1",
                Description = "Визначимо відстань між рівними по довжині рядками SA та SB (позначимо d(SA, SB)) як суму для всіх 1 ≤ i ≤ |SA| найкоротших відстаней між літерами SA(i) та SB(i) у циклічно замкнутому англійському алфавіті (тобто після букви «a» йде буква «b», ..., після букви «z» йде «a»). Наприклад, d(aba, aca) = 1, а d(aba, zbz) = 2. Потрібно порахувати ступінь циклічної відстані заданих рядків SA та SB.",
                InputDescription = "Два рядки рівної довжини, що не перевищує 105 символів. Рядки складаються лише з маленьких букв англійського алфавіту.",
                OutputDescription = "Ступінь циклічної відстані заданих рядків SA та SB.",
                ActionName = "FindLength"
            };
            return Ok(model);
        }

        [HttpGet("lab2")]
        public IActionResult GetLab2()
        {
            var model = new LabViewModel
            {
                LabNumber = 2,
                Title = "Лабораторна робота 2",
                Description = "Енти були створені в Початкову епоху разом з іншими мешканцями Середзем'я. Ельфійські легенди свідчать, що коли Варда запалила зірки і прокинулися Ельфи, разом із ними прокинулися й Енти у Великих Лісах Арди.\r\n\r\n    Коли Енти прийшли в Арду, вони ще не вміли говорити - цьому мистецтву їх навчали Ельфи, і Ентам це дуже подобалося. Їм приносило задоволення вивчати різні мови, навіть щебетання Людей.\r\n\r\n    Ельфи виробили хорошу техніку навчання ентів своєї мови. Перший ент, якого навчили ельфи, вивчив всього два слова - tancave (так) і la (ні). Навчений ент вибрав одного старого і одного молодого ента, які не вміють говорити, і навчив їх усім словам, які знав сам. Потім навчання цих двох ентів продовжили ельфи. Кожен ент, який навчився у ельфів, знову вибирав із небалакучих родичів одного старого і одного молодого, навчав їх усім словам, які знав, передавав ельфам і так далі.\r\n\r\n    З'ясувалося, що молодші енти вивчали в ельфів ще рівно стільки ж слів, скільки вони дізналися від ента, що навчав їх. А ось більш старі, вже схильні до здеревіння енти, поповнювали свій запас лише одним словом. Після навчання у ельфів енти до кінця світу вже не могли вивчити жодного нового слова.\r\n\r\n    Загальна кількість ентів у Середзем'ї більша, ніж ви думаєте. Цікаво, а скільки знають рівно 150 квенійських слів? Схоже завдання вам доведеться вирішити.",
                InputDescription = "Натуральні числа K і P (K ≤ 106; 1 ≤ P ≤ 109), записані через пропуск.",
                OutputDescription = "Кількість ентів, які знають рівно K слів, за модулем P.",
                ActionName = "EntCounter"
            };
            return Ok(model);
        }

        [HttpGet("lab3")]
        public IActionResult GetLab3()
        {
            var model = new LabViewModel
            {
                LabNumber = 3,
                Title = "Лабораторна робота 3",
                Description = "На площині розташовані кілька прямокутників. Кожен прямокутник на площині визначається координатами лівого нижнього кута (X1, Y1) і правого верхнього кута (X2, Y2), при цьому сторони прямокутників паралельні осям координат. При накладенні один на одного прямокутники утворюють фігури, окремо розташований прямокутник – теж фігура. Прямокутники, що торкаються лише кутами, не утворюють фігуру. Якщо прямокутники стикаються сторонами, вони теж утворюють фігуру. Потрібно визначити фігуру максимальної площі.",
                InputDescription = "У першому рядку записано кількість прямокутників N (1 ≤ N ≤ 25), далі йдуть N рядків з координатами вершин прямокутників X1, Y1, X2, Y2, розділених пробілом. Координати вершин - цілі, невід'ємні числа, в діапазоні від 0 до 100 включно.",
                OutputDescription = "Одне ціле число – площа знайденої фігури.",
                ActionName = "RectangleAreaSolver"
            };
            return Ok(model);
        }

        [HttpPost("run")]
        public IActionResult RunLab([FromForm] RunLabRequest request)
        {
            if (request.InputFile == null || request.InputFile.Length == 0)
            {
                return BadRequest("Будь ласка, завантажте файл.");
            }

            string inputFilePath = Path.Combine(Path.GetTempPath(), request.InputFile.FileName);
            using (var stream = new FileStream(inputFilePath, FileMode.Create))
            {
                request.InputFile.CopyTo(stream);
            }

            string outputFilePath = Path.Combine(Path.GetTempPath(), "output.txt");

            LabRunner labRunner = new LabRunner();
            switch (request.ActionName)
            {
                case "FindLength":
                    labRunner.RunLab1(inputFilePath, outputFilePath);
                    break;
                case "EntCounter":
                    labRunner.RunLab2(inputFilePath, outputFilePath);
                    break;
                case "RectangleAreaSolver":
                    labRunner.RunLab3(inputFilePath, outputFilePath);
                    break;
                default:
                    return BadRequest("Unknown lab action.");
            }

            string result = System.IO.File.ReadAllText(outputFilePath);
            return Ok(new { Result = result });
        }

    }
}
