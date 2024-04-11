using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.Address.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, CreateAddressCommandResponse>
    {
        private readonly IRepository<AddressEntity> _repository;

        public CreateAddressCommandHandler(IRepository<AddressEntity> repository)
        {
            _repository = repository;
        }

        public async Task<CreateAddressCommandResponse> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AddressEntity
            {
                City = request.City,
                Detail = request.Detail,
                District = request.District,
                UserId = request.UserId
            });
            return new CreateAddressCommandResponse { IsSuccess = true };
        }
    }
}
