using Microsoft.AspNetCore.Mvc;
using TGNH.Panel.Models;

namespace TGNH.Panel.Controllers;

public class StudentController : Controller
{
    public IActionResult Index()
    {
        var students = new List<Student>
        {
          new Student { Id = 1, Name = "alkxv", Age = 26, Email = "dlvkh@examole.com" },
          new Student { Id = 2, Name = "zvknxv", Age = 45, Email = "zdvlvkh@examole.com" },
          new Student { Id = 3, Name = "ZVCz", Age = 54, Email = "zdvzd@example.com" }
        };

       return View(students);
    }
}
