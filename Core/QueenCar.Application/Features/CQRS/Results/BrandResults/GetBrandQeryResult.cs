using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Application.Features.CQRS.Results.BrandResults
{
    public class GetBrandQeryResult
    {
        public int BrandID { get; set; }
        public string Name { get; set; }
    }
}
