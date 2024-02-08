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
    [Authorize(Roles = SD.Role_Admin)]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webhostEnvironment;

        public StudentController(IUnitOfWork unitOfWork, IWebHostEnvironment webhostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webhostEnvironment = webhostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        //GET
        public IActionResult Upsert(int? id)
        {
            StudentVM studentVM = new()
            {
               Student = new(),
               CourseList = _unitOfWork.Course.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),

            };

            if (id == null || id == 0)
            {
                //create student
                
                return View(studentVM);
            }
            else
            {
                studentVM.Student = _unitOfWork.Student.GetFirstOrDefault(u => u.Id == id);
                return View(studentVM);
                //update student
            }
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(StudentVM obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webhostEnvironment.WebRootPath;
                //se o ficheiro foi uploaded
                if (file != null)
                {
                    //mudar nome
                    string fileName = Guid.NewGuid().ToString();
                    //localização do ficheiro uploaded
                    var uploads = Path.Combine(wwwRootPath, @"images\students");
                    //renomear o ficheiro mas com a mesma extensão
                    var extension = Path.GetExtension(file.FileName);

                    //se existir a imagem, remover
                    if (obj.Student.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Student.ImageUrl.TrimStart('\\'));
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
                    obj.Student.ImageUrl = @"\images\students\" + fileName + extension;
                    //salvar na bd
                }
                if (obj.Student.Id == 0)
                {
                    _unitOfWork.Student.Add(obj.Student);

                }
                else
                {
                    _unitOfWork.Student.Update(obj.Student);
                }
                _unitOfWork.Save();
                TempData["success"] = "Student created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        #region API CALLS
        //all
        [HttpGet]
        public IActionResult GetAll()
        {
            var studentList = _unitOfWork.Student.GetAll(includeProperties: "Course");
            return Json(new { data = studentList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Student.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            //remover a imagem associada se existir
            var oldImagePath = Path.Combine(_webhostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Student.Remove(obj);
            _unitOfWork.Save();
            //mensagem de sucesso
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
