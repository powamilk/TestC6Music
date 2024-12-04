using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ArtisRepo : IArtisRepo
    {
        private readonly AppDbContext _context;

        public ArtisRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Artist artist)
        {
            await _context.Artists.AddAsync(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _context.Artists.FindAsync(id);
            if (existing != null)
            {
                _context.Artists.Remove(existing);  
                await _context.SaveChangesAsync();
            }    

        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _context.Artists.ToListAsync();
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            return await _context.Artists.AsNoTracking().FirstOrDefaultAsync(e => e.ArtistId == id);
        }

        public async Task UpdateAsync(Artist artist)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
        }
    }
}
