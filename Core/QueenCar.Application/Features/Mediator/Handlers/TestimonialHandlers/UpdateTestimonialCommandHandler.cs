using MediatR;
using QueenCar.Application.Features.Mediator.Commands.TestimonialCommands;
using QueenCar.Application.Interfaces;
using QueenCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.TestimonialId);
            if (value == null)
            {
                throw new Exception($"Id={request.TestimonialId} için kayıt bulunamadı");
            }
            value.Name = request.Name;
            value.Title = request.Title;
            value.ImageUrl = request.ImageUrl;
            value.Comment = request.Comment;
            await _repository.UpdateAsync(value);
        }
    }
}
