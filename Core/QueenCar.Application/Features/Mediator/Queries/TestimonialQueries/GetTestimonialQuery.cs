using MediatR;
using QueenCar.Application.Features.Mediator.Results.TestimonialResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialQuery: IRequest<List<GetTestimonialQueryResult>>
    {
    }
}
