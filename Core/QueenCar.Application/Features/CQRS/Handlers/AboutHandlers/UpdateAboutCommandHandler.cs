 using QueenCar.Application.Features.CQRS.Commands.AboutCommands;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AboutId);
            if (value == null)
            {
                throw new Exception($"Id={command.AboutId} için kayıt bulunamadı");
            }
            value.Title = command.Title;
            value.Description = command.Description;
            value.IconUrl = command.IconUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
