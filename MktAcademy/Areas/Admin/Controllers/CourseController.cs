using Microsoft.AspNetCore.Mvc;
using MktAcademy.DataAccess.Data;
using MktAcademy.Models;
using MktAcademy.DataAccess.Repository;
using MktAcademy.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using MktAcademy.Utility;
using MktAcademy.Models.ViewModels;
using MktAcademy.Areas.Admin.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace MktAcademy.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public CourseController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            CourseVM courseVM = new()
            {
                Course = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

            };

            if (id == null || id == 0)
            {
                //create course
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CategoryList"] = CategoryList;
                return View(courseVM);
            }
            else
            {
                courseVM.Course = _unitOfWork.Course.GetFirstOrDefault(u => u.Id == id);
                return View(courseVM);
                //update course
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CourseVM obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                //se o ficheiro foi uploaded
                if (file != null)
                {
                    //mudar nome
                    string fileName = Guid.NewGuid().ToString();
                    //localização do ficheiro uploaded
                    var uploads = Path.Combine(wwwRootPath, @"images\courses");
                    //renomear o ficheiro mas com a mesma extensão
                    var extension = Path.GetExtension(file.FileName);

                    //se existir a imagem, remover
                    if (obj.Course.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Course.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    //Copiar 
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        //copiar o ficheiro
                        file.CopyTo(fileStreams);
                    }
                    obj.Course.ImageUrl = @"\images\courses\" + fileName + extension;
                    //salvar na bd
                }
                if (obj.Course.Id == 0)
                {
                    _unitOfWork.Course.Add(obj.Course);

                }
                else
                {
                    _unitOfWork.Course.Update(obj.Course);
                }
                _unitOfWork.Save();
                TempData["success"] = "Course created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        #region API CALLS
        //all products
        [HttpGet]
        public IActionResult GetAll()
        {
            var courseList = _unitOfWork.Course.GetAll(includeProperties: "Category");
            return Json(new { data = courseList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Course.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            //remover a imagem associada se existir
            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Course.Remove(obj);
            _unitOfWork.Save();
            //mensagem de sucesso
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
