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
	public class CourseRepository : Repository<Course>, ICourseRepository
	{
		private ApplicationDbContext _db;
		public CourseRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public IEnumerable<Course> Get(Func<object, bool> value, string includeProperties)
		{
			throw new NotImplementedException();
		}

		public void Update(Course obj)
		{
			//_db.Courses.Update(obj);

			var objFromDb = _db.Courses.FirstOrDefault(u => u.Id == obj.Id);
			if (objFromDb != null)
			{
				objFromDb.Name = obj.Name;
				objFromDb.Description = obj.Description;
				objFromDb.ListPrice = obj.ListPrice;
				objFromDb.Price20 = obj.Price20;
				objFromDb.Remarks = obj.Remarks;
				
			}
		}
	}
}
