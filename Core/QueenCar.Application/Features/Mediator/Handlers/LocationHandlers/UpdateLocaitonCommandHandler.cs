using MediatR;
using QueenCar.Application.Features.Mediator.Commands.LocationCommands;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly IRepository<Location> _repository;

        public UpdatePricingCommandHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.LocationID);
            if (value == null)
            {
                throw new Exception($"Id={request.LocationID} için kayıt bulunamadı");
            }
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
