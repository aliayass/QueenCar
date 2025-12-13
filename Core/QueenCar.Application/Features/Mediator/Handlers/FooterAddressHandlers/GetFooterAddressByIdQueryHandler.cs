using MediatR;
using QueenCar.Application.Features.Mediator.Queries.FooterAddressQueries;
using QueenCar.Application.Features.Mediator.Results.FooterAddressResults;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
           var value = await _repository.GetByIdAsync(request.Id);

            if (value == null)
            {
                throw new Exception($"Id={request.Id} için kayıt bulunamadı"); ;
                // veya throw new Exception($"Id={query.Id} için kayıt bulunamadı");
            }
            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressID = value.FooterAddressID,
                Description = value.Description,
                Address = value.Address,
                Phone = value.Phone,
                Email = value.Email
            };
        }
    }
}
