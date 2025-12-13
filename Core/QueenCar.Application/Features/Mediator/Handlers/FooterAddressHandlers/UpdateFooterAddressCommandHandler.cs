using MediatR;
using QueenCar.Application.Features.Mediator.Commands.FooterAddressCommands;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.FooterAddressID);
            if (value == null)
            {
                throw new Exception($"Id={request.FooterAddressID} için kayıt bulunamadı");
            }
            await _repository.UpdateAsync(new FooterAddress
            {
                Description = request.Description,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email
            });
        }
    }
}
