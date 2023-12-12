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
	public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
	{
		private ApplicationDbContext _db;
		public EnrollmentRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public IEnumerable<Enrollment> Get(Func<object, bool> value, string includeProperties)
		{
			throw new NotImplementedException();
		}

		public void Update(Enrollment obj)
		{
			_db.Enrollments.Update(obj);

			
		}
	}
}
