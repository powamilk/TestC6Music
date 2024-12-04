using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public partial class Artist
    {
        public int ArtistId { get; set; }
        public string Name { get; set; } = null!;
        public string? Bio { get; set; }
        public string? Country { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? ImagePath { get; set; }
    }
}
