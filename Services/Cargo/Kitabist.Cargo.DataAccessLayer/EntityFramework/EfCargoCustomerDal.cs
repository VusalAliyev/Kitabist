using Kitabist.Cargo.DataAccessLayer.Abstract;
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
    public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        private readonly CargoContext _cargoContext;
        public EfCargoCustomerDal(CargoContext context, CargoContext cargoContext) : base(context)
        {
            _cargoContext = cargoContext;
        }
        public CargoCustomer GetCargoCustomerById(string id)
        {
            var values = _cargoContext.CargoCustomers.Where(x => x.UserCustomerId == id).FirstOrDefault();
            return values;
        }
    }
}
