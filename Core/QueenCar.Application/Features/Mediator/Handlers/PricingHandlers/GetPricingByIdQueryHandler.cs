using MediatR;
using QueenCar.Application.Features.Mediator.Queries.PricingQueries;
using QueenCar.Application.Features.Mediator.Results.PricingResults;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetServiceByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                throw new Exception($"Id={request.Id} için kayıt bulunamadı"); ;
                // veya throw new Exception($"Id={query.Id} için kayıt bulunamadı");
            }
            return new GetServiceByIdQueryResult
            {
                PricingId = value.PricingId,
                Name = value.Name
            };
        }
    }
}
