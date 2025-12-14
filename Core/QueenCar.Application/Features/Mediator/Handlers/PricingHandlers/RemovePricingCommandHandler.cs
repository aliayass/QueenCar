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
    public class RemoveServiceCommandHandler : IRequestHandler<RemovePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public RemoveServiceCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePricingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                throw new Exception($"Id={request.Id} için kayıt bulunamadı");
            }
            await _repository.RemoveAsync(value);
        }
    }
}
