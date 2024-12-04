using DAL.Entities;

namespace PL.Service
{
    public interface IArtisService
    {
        Task<IEnumerable<Artist>> GetAllAsync();
        Task<Artist> GetByIdAsync(int id);
        Task AddAsync(Artist artist);
        Task UpdateAsync(int id, Artist artist);
        Task DeleteAsync(int id);
    }
}
