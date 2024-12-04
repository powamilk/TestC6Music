using BUS.Service;
using DAL.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/artist")]
    [ApiController]
    public class ArtisController : ControllerBase
    {
        private readonly IArtisService _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArtisController(IArtisService service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var artis = await _service.GetAllAsync();
            return Ok(artis);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var artis = await _service.GetByIdAsync(id);
            if(artis == null)
            {
                return NotFound();
            }    
            return Ok(artis);
            
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Artist artis)
        {
            await _service.AddAsync(artis);
            return Ok(artis);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Artist artis )
        {
            var arti = await _service.GetByIdAsync(id);
            if (arti == null)
            {
                return NotFound();
            }
            await _service.UpdateAsync(artis);
            return Ok(artis);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var arti = await _service.GetByIdAsync(id);
            if (arti == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            var imageUrl = "/images/" + fileName;
            return Ok(imageUrl); 
        }

    }
}
