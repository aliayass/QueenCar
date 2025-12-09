using QueenCar.Application.Features.CQRS.Results.BrandResults;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _repository;
        public GetBrandByIdQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task<GetBrandByIdQeryResult> Handle(GetBrandByIdQeryResult query)
        {
            var x = await _repository.GetByIdAsync(query.BrandID);
            if (x == null)
            {
                throw new Exception($"Id={query.BrandID} için kayıt bulunamadı");
            }
            return new GetBrandByIdQeryResult
            {
                BrandID = x.BrandID,
                Name = x.Name
            };
        }
    }
}
