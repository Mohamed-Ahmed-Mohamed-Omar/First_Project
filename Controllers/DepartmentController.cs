using First_Project.BL.Interface;
using First_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace First_Project.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        // Loosly Coupled 

        private readonly IDepartmentRep _departmentRep;
        public DepartmentController(IDepartmentRep departmentRep)
        {
            _departmentRep = departmentRep;
        }
        public IActionResult Index()
        {
            var data = _departmentRep.Get();

            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _departmentRep.Add(dpt);

                    return RedirectToAction("Index", "Department");
                }

                return View(dpt);
            }
            catch (Exception ex)
            {
                return View(dpt);
            }
        }

        public IActionResult Edit(int id)
        {
            var data = _departmentRep.GetById(id);

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(DepartmentVM dpt)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    _departmentRep.Edit(dpt);

                    return RedirectToAction("Index", "Department");
                }

                return View(dpt);
            }
            catch (Exception ex)
            {
                return View(dpt);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = _departmentRep.GetById(id);

            return View(data);
        }

        [HttpPost]
        [ActionName("Delete")] // change Name in runtime
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                _departmentRep.Delete(id);

                return RedirectToAction("Index", "Depart");

            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
