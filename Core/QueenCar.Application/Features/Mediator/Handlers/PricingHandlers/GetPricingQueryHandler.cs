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
    public class GetServiceQueryHandler : IRequestHandler<GetPricingQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Pricing> _repository;

        public GetServiceQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values  =  await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                PricingId = x.PricingId,
                Name = x.Name
            }).ToList();
        }
    }
}
