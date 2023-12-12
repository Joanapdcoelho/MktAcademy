using MktAcademy.DataAccess.Data;
using MktAcademy.DataAccess.Repository.IRepository;
using MktAcademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MktAcademy.DataAccess.Repository;

namespace MktAcademy.DataAccess.Repository
{
	public class InstructorRepository : Repository<Instructor>, IInstructorRepository
	{
		private ApplicationDbContext _db;
		public InstructorRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public IEnumerable<Instructor> Get(Func<object, bool> value, string includeProperties)
		{
			throw new NotImplementedException();
		}

		public void Update(Instructor obj)
		{
			//_db.Courses.Update(obj);

			var objFromDb = _db.Instructors.FirstOrDefault(u => u.ID == obj.ID);
			if (objFromDb != null)
			{
				objFromDb.FirstName = obj.FirstName;
				objFromDb.LastName = obj.LastName;
				objFromDb.DateOfBirth = obj.DateOfBirth;
				objFromDb.HireDate = obj.HireDate;


			}
		}
	}
}
