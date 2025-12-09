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
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _repository;

        public GetBrandQueryHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBrandQeryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBrandQeryResult
            {
                BrandID = x.BrandID,
                Name = x.Name
            }).ToList();
        }
    }
}
