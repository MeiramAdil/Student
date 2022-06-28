using Microsoft.AspNetCore.Mvc;
using Students.Data;
using Students.Models;
using System.Text.Json;

namespace Students.Controllers
{
  public class StudentController : Controller
  {
    public AppDbContext db { get; set; }

    public StudentController(AppDbContext db)
    {
      this.db = db;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult CreateStudent(Student student)
    {
      db.Students.Add(student);
      db.SaveChanges();
      string message = "SUCCESS";
      return Ok(student);
    }
    [HttpPost]
    public IActionResult EditStudent(int id)
    {
      var std = db.Students.Find(id);
      string message = "SUCCESS";

      return Json(new { Message = message });
    }
    [HttpPost]
    public IActionResult DeleteStudent(int id)
    {
      var std = db.Students.Find(id);
      db.Students.Remove(std);
      db.SaveChanges();
      string message = "SUCCESS";
      return Ok(std);
    }

    public IActionResult GetStudent(int id)
    {
      List<Student> students = new List<Student>();
      students = db.Students.ToList();
      return Ok(students);
    }
  }
}
