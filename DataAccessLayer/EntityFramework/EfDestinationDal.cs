﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public List<Destination> GetLast4Destinations()
        {
            using (var context = new Context())
            {
                var value = context.Destinations.Take(4).OrderByDescending(x => x.DestinationID).ToList();
                return value;
            }
        }
    }
}
