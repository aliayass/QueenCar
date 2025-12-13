using QueenCar.Application.Features.CQRS.Commands.ContactCommands;
using QueenCar.Application.Features.CQRS.Queries.ContactQueries;
using QueenCar.Application.Features.CQRS.Results.ContactResults;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            if (value == null)
                throw new Exception($"Id={query.Id} için kayıt bulunamadı");
            return new GetContactByIdQueryResult
            {
                ContactId = value.ContactId,
                Name = value.Name,
                Email = value.Email,
                Subject = value.Subject,
                Message = value.Message,
                SendDate = value.SendDate
            };
        }
    }

}


