using MktAcademy.DataAccess;
using MktAcademy.DataAccess.Repository.IRepository;
using MktAcademy.Models;
using MktAcademy.Models.ViewModels;
using MktAcademy.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace MktAcademyWeb.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class UserController : Controller
{    
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IUnitOfWork _unitOfWork;
    public UserController(UserManager<IdentityUser> userManager, IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager)
    {
        _unitOfWork = unitOfWork;
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }    
    

    #region API CALLS
    [HttpGet]
    public IActionResult GetAll()
    {
        List<ApplicationUser> objUserList = _unitOfWork.ApplicationUser.GetAll(includeProperties: "Company").ToList();

        foreach (var user in objUserList)
        {

            user.Role = _userManager.GetRolesAsync(user).GetAwaiter().GetResult().FirstOrDefault();

            if (user.Company == null)
            {
                user.Company = new Company()
                {
                    Name = ""
                };
            }
        }

        return Json(new { data = objUserList });
    }

    //POST
    [HttpPost]
    public IActionResult LockUnlock([FromBody] string id)
    {

        var objFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == id);
        if (objFromDb == null)
        {
            return Json(new { success = false, message = "Error while Locking/Unlocking" });
        }

        if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
        {
            //user is currently locked and we need to unlock them
            objFromDb.LockoutEnd = DateTime.Now;
        }
        else
        {
            objFromDb.LockoutEnd = DateTime.Now.AddYears(100);
        }
        _unitOfWork.ApplicationUser.Update(objFromDb);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Operation Successful" });
    }
    #endregion
}
