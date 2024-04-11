using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.Address.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, UpdateAddressCommandResponse>
    {
        private readonly IRepository<AddressEntity> _repository;

        public UpdateAddressCommandHandler(IRepository<AddressEntity> repository)
        {
            _repository = repository;
        }

        public async Task<UpdateAddressCommandResponse> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAsync(new Domain.Entities.Address
            {
                AdressId = request.AdressId,
                City = request.City,
                Detail = request.Detail,
                District = request.District,
                UserId = request.UserId,
            });

            return new UpdateAddressCommandResponse { IsSuccess = true };
        }
    }
}
