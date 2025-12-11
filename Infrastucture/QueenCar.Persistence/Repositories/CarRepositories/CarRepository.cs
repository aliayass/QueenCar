using Microsoft.EntityFrameworkCore;
using QueenCar.Application.Interfaces;
using QueenCar.Application.Interfaces.CarInterfaces;
using QueenCar.Domain.Entities;
using QueenCar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenCar.Persistence.Repositories.CarRepository
{
    public class CarRepository : ICarRepository
    {
        private readonly QueenCarContext _context;

        public CarRepository(QueenCarContext context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarsListWithBrand()
        {
           return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }
    }
}
