using QueenCar.Application.Features.CQRS.Commands.BrandCommands;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBrandCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BrandID);
            if (values == null)
            {
                throw new Exception($"Id={command.BrandID} için kayıt bulunamadı");
            }
            values.Name = command.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
