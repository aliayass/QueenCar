using MediatR;
using QueenCar.Application.Features.Mediator.Queries.TestimonialQueries;
using QueenCar.Application.Features.Mediator.Results.TestimonialResults;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            if (value == null)
            {
                throw new Exception($"Id={request.Id} için kayıt bulunamadı"); ;
                // veya throw new Exception($"Id={query.Id} için kayıt bulunamadı");
            }
            return new GetTestimonialByIdQueryResult
            {
                TestimonialId = value.TestimonialId,
                Name = value.Name,
                Title = value.Title,
                ImageUrl = value.ImageUrl,
                Comment = value.Comment,
            };
        }
    }
}
