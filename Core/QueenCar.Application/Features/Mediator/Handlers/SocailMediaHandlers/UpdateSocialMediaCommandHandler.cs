using MediatR;
using QueenCar.Application.Features.Mediator.Commands.SocialMediaCommands;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.SocialMediaID);
            if (value == null)
            {
                throw new Exception($"Id={request.SocialMediaID} için kayıt bulunamadı");
            }
            value.Name = request.Name;
            value.Url = request.Url;
            value.Icon = request.Icon;
            await _repository.UpdateAsync(value);
        }
    }
}
