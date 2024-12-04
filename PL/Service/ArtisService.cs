using DAL.Entities;

namespace PL.Service
{
    public class ArtisService : IArtisService
    {
        private readonly HttpClient _httpClient;

        public ArtisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7291/api/");
        }

        public async Task AddAsync(Artist artist)
        {
            await _httpClient.PostAsJsonAsync("artist", artist);
        }

        public async Task DeleteAsync(int id)
        {
             await _httpClient.DeleteAsync($"artist/{id}");
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            var response = await _httpClient.GetAsync("artist");
            if(response.IsSuccessStatusCode)
            {
                var artis = await response.Content.ReadFromJsonAsync<IEnumerable<Artist>>();
                return artis ?? new List<Artist>(); 
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"artist/{id}");
            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<Artist>();
            }
            throw new Exception($"Id ko ton tai");
        }

        public async Task UpdateAsync(int id, Artist artist)
        {
            var response = await _httpClient.PutAsJsonAsync($"artist/{id}", artist);
            if(!response.IsSuccessStatusCode)
            {
                var eror = await response.Content.ReadAsStringAsync();
                throw new Exception(eror);
            }    
        }
    }
}
