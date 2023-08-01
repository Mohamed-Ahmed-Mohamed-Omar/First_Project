using First_Project.BL.Interface;
using First_Project.BL.Repository;
using First_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace First_Project.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {
        private readonly IStudentRep _studentRep;
        private readonly IDepartmentRep _departmentRep;

        public StudentController(IStudentRep studentRep, IDepartmentRep departmentRep)
        {
            _studentRep = studentRep;
            _departmentRep = departmentRep;
        }

        public IActionResult Index()
        {
            var data = _studentRep.Get();

            return View(data);
        }

        public IActionResult Create()
        {
            var data = _departmentRep.Get();

            ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");

            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentVM std)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _studentRep.Add(std);
                    return RedirectToAction("Index", "Student");
                }

                var data = _departmentRep.Get();

                ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName");

                return View(std);
            }
            catch (Exception ex)
            {
                return View(std);
            }
        }

        public IActionResult Edit(int id)
        {
            var data = _studentRep.GetById(id);

            var Deptdata = _departmentRep.Get();

            ViewBag.DepartmentList = new SelectList(Deptdata, "Id", "DepartmentName", data.DepartmentId);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(StudentVM std)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentRep.Edit(std);
                    return RedirectToAction("Index", "Student");
                }

                var data = _departmentRep.Get();

                ViewBag.DepartmentList = new SelectList(data, "Id", "DepartmentName", std.DepartmentId);

                return View(std);
            }
            catch (Exception ex)
            {
                return View(std);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = _studentRep.GetById(id);

            var Dptdata = _departmentRep.Get();

            ViewBag.DepartmentList = new SelectList(Dptdata, "Id", "DepartmentName", data.DepartmentId);

            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                _studentRep.Delete(id);
                return RedirectToAction("Index", "Student");
            }
            catch (Exception ex)
            {

                return View();
            }
        }
    }
}
