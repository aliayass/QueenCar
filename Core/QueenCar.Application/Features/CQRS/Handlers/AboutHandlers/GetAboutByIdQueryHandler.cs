using QueenCar.Application.Features.CQRS.Queries.AboutQueries;
using QueenCar.Application.Features.CQRS.Results.AboutResults;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);

            if (values == null)
            {
                throw new Exception($"Id={query.Id} için kayıt bulunamadı"); ;
                // veya throw new Exception($"Id={query.Id} için kayıt bulunamadı");
            }

            return new GetAboutByIdQueryResult
            {
                AboutId = values.AboutId,
                Title = values.Title,
                Description = values.Description,
                IconUrl = values.IconUrl
            };
        }
    }
}
