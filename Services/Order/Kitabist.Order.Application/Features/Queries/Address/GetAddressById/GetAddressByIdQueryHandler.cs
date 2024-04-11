using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Queries.Address.GetAddressById
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQueryRequest, GetAddressByIdQueryResponse>
    {
        private readonly IRepository<AddressEntity> _repository;

        public GetAddressByIdQueryHandler(IRepository<AddressEntity> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResponse> Handle(GetAddressByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var address = await _repository.GetByIdAsync(request.Id);

            return new GetAddressByIdQueryResponse
            {
                AdressId = address.AdressId,
                City = address.City,
                Detail = address.Detail,
                District = address.District,
                UserId = address.UserId,
            };
        }
    }
}
