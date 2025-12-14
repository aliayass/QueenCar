using MediatR;
using QueenCar.Application.Features.Mediator.Results.LocationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationQuery: IRequest<List<GetLocationQueryResult>>
    {
    }
}
