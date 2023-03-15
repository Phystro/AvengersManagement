using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvengersManagement.Data;

namespace AvengersManagement.Services.AvengerService
{
    public class AvengerService : IAvengerService
    {
        // private static List<Avenger> avengers = new List<Avenger>
        // {
        //     new Avenger
        //     {
        //         Id = 1,
        //         Name = "Iron Man",
        //         FirstName = "Tony",
        //         LastName = "Stark",
        //         Place = "Malibu",
        //     },
        //     new Avenger
        //     {
        //         Id = 2,
        //         Name = "Spider Man",
        //         FirstName = "Peter",
        //         LastName = "Parker",
        //         Place = "New York City",
        //     }
        // };

        private readonly AvengerContext _context;

        public AvengerService(AvengerContext context)
        {
            _context = context;
        }

        public async Task<Avenger> CreateAsync(Avenger request)
        {
            _context.Avengers.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task DeleteAsync(int id)
        {
            Avenger avenger = new(){Id = id};
            _context.Avengers.Remove(avenger);

            await _context.SaveChangesAsync();
        }

        public Task<List<Avenger>> QueryAsync()
        {
            return _context.Avengers.ToListAsync();
        }

        public async Task<Avenger?> ReadAsync(int id)
        {
            Avenger? result = await _context.Avengers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Avenger?> UpdateAsync(Avenger request)
        {
            Avenger? existing = await _context.Avengers.FindAsync(request.Id);
            if(existing is null) return null;

            existing.Name = request.Name;
            existing.FirstName = request.FirstName;
            existing.LastName = request.LastName;
            existing.Place = request.Place;

            await _context.SaveChangesAsync();
            return existing;
        }

    }
}