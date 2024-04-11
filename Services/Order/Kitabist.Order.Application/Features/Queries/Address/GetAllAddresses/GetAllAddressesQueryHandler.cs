using Kitabist.Order.Application.Features.Queries.Order.GetAllOrders;
using Kitabist.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Queries.Address.GetAllAddresses
{
    public class GetAllAddressesQueryHandler : IRequestHandler<GetAllAddressesQueryRequest, List<GetAllAddressesQueryResponse>>
    {
        private readonly IRepository<AddressEntity> _repository;

        public GetAllAddressesQueryHandler(IRepository<AddressEntity> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAllAddressesQueryResponse>> Handle(GetAllAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            var addresses = await _repository.GetAllAsync();

            return addresses.Select(a => new GetAllAddressesQueryResponse
            {
                AdressId = a.AdressId,
                City = a.City,
                Detail = a.Detail,
                District = a.District,
                UserId = a.UserId,
            }).ToList();

        }
    }
}
