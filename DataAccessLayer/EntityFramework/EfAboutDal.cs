using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAboutDal :GenericRepository<About> , IAboutDal
    {
        //IAboutdal da sadece buna özgü bir metot girdiğimiz zaman gelip burada implement ederiz
    }
}
