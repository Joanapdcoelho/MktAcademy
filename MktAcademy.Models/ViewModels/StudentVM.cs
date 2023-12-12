﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MktAcademy.Models.ViewModels
{
    public class StudentVM
    {
        public Student Student { get; set; }
        public IEnumerable<SelectListItem> CourseList { get; set; }
    }
}
