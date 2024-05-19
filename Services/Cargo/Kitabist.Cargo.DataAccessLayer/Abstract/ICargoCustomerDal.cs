﻿using Kitabist.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Cargo.DataAccessLayer.Abstract
{
    public interface ICargoCustomerDal:IGenericDal<CargoCustomer>
    {
        CargoCustomer GetCargoCustomerById(string id);
    }
}