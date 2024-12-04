using DAL.Entities;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Service
{
    public class ArtisService : IArtisService
    {
        private readonly IArtisRepo _repo;

        public ArtisService(IArtisRepo repo)
        {
            _repo = repo;
        }

        public async Task AddAsync(Artist artist)
        {
           await _repo.AddAsync(artist);
        }

        public async Task DeleteAsync(int id)
        {
            await _repo.DeleteAsync(id);    
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
           return await _repo.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Artist artist)
        {
            await _repo.UpdateAsync(artist); 
        }
    }
}
