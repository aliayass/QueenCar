using QueenCar.Application.Features.CQRS.Commands.BannerCommands;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle (RemoveBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            if (value == null)
            {
                throw new Exception($"Id={command.Id} için kayıt bulunamadı");
            }
            await _repository.RemoveAsync(value);
        }
    }
}
