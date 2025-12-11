using QueenCar.Application.Features.CQRS.Commands.CarCommands;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle (UpdateCarCommand command)
        {
            var value = await _repository.GetByIdAsync(command.CarID);
            if(value == null)
                throw new Exception($"Id={command.CarID} için kayıt bulunamadı");
            value.CarID = command.CarID;
            value.BrandID = command.BrandID;
            value.Model = command.Model;
            value.CoverImageUrl = command.CoverImageUrl;
            value.Km = command.Km;
            value.Transmission = command.Transmission;
            value.Seat = command.Seat;
            value.Luggage = command.Luggage;
            value.Fuel = command.Fuel;
            value.BigImageUrl = command.BigImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
