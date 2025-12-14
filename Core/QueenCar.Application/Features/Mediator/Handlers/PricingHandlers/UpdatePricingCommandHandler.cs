using MediatR;
using QueenCar.Application.Features.Mediator.Commands.PricingCommands;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdateServiceCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.PricingId);
            if (value == null)
            {
                throw new Exception($"Id={request.PricingId} için kayıt bulunamadı");
            }
            value.Name = request.Name;
            await _repository.UpdateAsync(value);
        }
    }
}
