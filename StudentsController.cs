using Microsoft.AspNetCore.Mvc;
using ViewsApp.Models;

namespace ViewsApp.Controllers
{
    public class StudentsController : Controller
    {
        // Временное хранилище студентов в памяти
        private static List<Student> _students = new List<Student>
        {
            new Student { Id = 1, Name = "Иван Петров", Age = 20, Group = "ПИ-21", City = "Москва" },
            new Student { Id = 2, Name = "Анна Смирнова", Age = 19, Group = "ПИ-22", City = "Санкт-Петербург" },
            new Student { Id = 3, Name = "Олег Кузнецов", Age = 21, Group = "ПИ-20", City = "Казань" }
        };

        // GET: /Students
        public IActionResult Index()
        {
            ViewData["Title"] = "Список студентов";
            ViewBag.Count = _students.Count;
            return View(_students);
        }

        // GET: /Students/Details/5
        public IActionResult Details(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        // GET: /Students/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Students/Create
        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.Id = _students.Count + 1;
            _students.Add(student);

            // Сообщение для отображения после редиректа
            TempData["Message"] = $"Студент '{student.Name}' успешно добавлен!";

            return RedirectToAction("Index");
        }
    }
}
