using Cinema.Core.DataAccess.EntityFramework;
using Cinema.DataAccess.Abstract;
using Cinema.DataAccess.Concrete.EntityFramework.Context;
using Cinema.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DataAccess.Concrete.EntityFramework
{
    public class DepartmentDal:BaseRepository<Department>,IDepartmentDal
    {
        public DepartmentDal(CinemaContext context):base(context)
        {

        }
    }
}
