using MediatR;
using QueenCar.Application.Features.Mediator.Queries.LocationQueries;
using QueenCar.Application.Features.Mediator.Results.LocationResults;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;

        public GetPricingByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                throw new Exception($"Id={request.Id} için kayıt bulunamadı"); ;
                // veya throw new Exception($"Id={query.Id} için kayıt bulunamadı");
            }
            return new GetLocationByIdQueryResult
            {
                LocationID = value.LocationID,
                Name = value.Name
            };
        }
    }
}
