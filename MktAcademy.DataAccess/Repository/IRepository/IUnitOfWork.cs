using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MktAcademy.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICourseRepository Course { get; }
        IApplicationUserRepository ApplicationUser { get; }
        ICompanyRepository Company { get; }
        

        void Save();
    }
}
