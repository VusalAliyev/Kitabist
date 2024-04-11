using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitabist.Order.Application.Features.Commands.Address.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommandRequest, DeleteAddressCommandResponse>
    {
        private readonly IRepository<AddressEntity> _repository;

        public DeleteAddressCommandHandler(IRepository<AddressEntity> repository)
        {
            _repository = repository;
        }

        public async Task<DeleteAddressCommandResponse> Handle(DeleteAddressCommandRequest request, CancellationToken cancellationToken)
        {
            //var deletedAddress = await _repository.GetByIdAsync(request.AdressId);
            await _repository.DeleteAsync(request.AdressId);

            return new DeleteAddressCommandResponse { IsSuccess = true };



        }
    }
}
