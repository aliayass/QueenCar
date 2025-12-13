using MediatR;
using QueenCar.Application.Features.Mediator.Queries.FeatureQueries;
using QueenCar.Application.Features.Mediator.Results.FeatureResults;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IRepository<Feature> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Feature> repository)
        {
            this._repository = repository;
        }

        public async Task <GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {

            var value = await _repository.GetByIdAsync(request.Id);

            if (value == null)
            {
                throw new Exception($"Id={request.Id} için kayıt bulunamadı"); ;
                // veya throw new Exception($"Id={query.Id} için kayıt bulunamadı");
            }

            return new GetFeatureByIdQueryResult
            {
                FeatureID = value.FeatureID,
                Name = value.Name
            };
        }
    }
}
