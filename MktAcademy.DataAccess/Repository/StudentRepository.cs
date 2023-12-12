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
	public class StudentRepository : Repository<Student>, IStudentRepository
	{
		private ApplicationDbContext _db;
		public StudentRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public IEnumerable<Student> Get(Func<object, bool> value, string includeProperties)
		{
			throw new NotImplementedException();
		}

		public void Update(Student obj)
		{
			//_db.Courses.Update(obj);

			var objFromDb = _db.Students.FirstOrDefault(u => u.Id == obj.Id);
			if (objFromDb != null)
			{
				objFromDb.FirstName = obj.FirstName;
				objFromDb.LastName = obj.LastName;
				objFromDb.DateOfBirth = obj.DateOfBirth;
				objFromDb.Address = obj.Address;
				objFromDb.City = obj.City;
				objFromDb.PostalCode = obj.PostalCode;
				objFromDb.EnrollmentDate = obj.EnrollmentDate;				

			}
		}
	}
}
