using MediatR;
using QueenCar.Application.Features.Mediator.Results.PricingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.Mediator.Queries.PricingQueries
{
    public class GetPricingQuery:IRequest<List<GetServiceQueryResult>>
    {
    }
}
