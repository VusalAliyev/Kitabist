﻿using Kitabist.Cargo.DataAccessLayer.Abstract;
using Kitabist.Cargo.DataAccessLayer.Concrete;
using Kitabist.Cargo.DataAccessLayer.Repository;
using Kitabist.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
    {
        public EfCargoCompanyDal(CargoContext context) : base(context)
        {

        }
    }
}
