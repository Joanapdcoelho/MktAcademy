using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MktAcademy.DataAccess.Data;
using MktAcademy.DataAccess.Repository.IRepository;
using MktAcademy.Models;
using MktAcademy.Models.ViewModels;
using System.Collections.Generic;

namespace MktAcademy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CourseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Course> objCourseList = _unitOfWork.Course.GetAll().ToList();           
            return View(objCourseList);
        }

        //GET Create
        public IActionResult Create()
        {
            CourseVM courseVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }
            ),
                Course = new Course()
            };
            return View(courseVM);
        }     

        //POST Create
        [HttpPost]
        public IActionResult Create(CourseVM courseVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Course.Add(courseVM.Course);
                _unitOfWork.Save();
                TempData["success"] = "Course created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                courseVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(courseVM);
            }        

        }

        //Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Course? courseFromDb = _unitOfWork.Course.Get(u => u.Id == id);

            if (courseFromDb == null)
            {
                return NotFound();
            }

            return View(courseFromDb);
        }


        //POST Edit
        [HttpPost]
        public IActionResult Edit(Course obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Course.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Course updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Course courseFromDb = _unitOfWork.Course.Get(u => u.Id == id);

            if (courseFromDb == null)
            {
                return NotFound();
            }

            return View(courseFromDb);
        }

        //POST Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Course obj = _unitOfWork.Course.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Course.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Course deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
