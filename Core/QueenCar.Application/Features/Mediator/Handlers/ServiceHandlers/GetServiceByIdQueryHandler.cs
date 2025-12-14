using MediatR;
using QueenCar.Application.Features.Mediator.Queries.ServiceQueries;
using QueenCar.Application.Features.Mediator.Results.ServiceResults;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                throw new Exception($"Id={request.Id} için kayıt bulunamadı"); ;
                // veya throw new Exception($"Id={query.Id} için kayıt bulunamadı");
            }
            return new GetServiceByIdQueryResult
            {
                ServiceID = value.ServiceID,
                Title = value.Title,
                Description = value.Description,
                IconUrl = value.IconUrl,
            };
        }
    }
}
