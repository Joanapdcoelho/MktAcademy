using MktAcademy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MktAcademy.DataAccess.Repository.IRepository
{
	public interface IInstructorRepository : IRepository<Instructor>
	{
		IEnumerable<Instructor> Get(Func<object, bool> value, string includeProperties);
		void Update(Instructor obj);

	}
}
