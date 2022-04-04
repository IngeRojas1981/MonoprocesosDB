using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCore.MongoDB.CRUD.Models
{
    public class SongViewModels
    {
        public Song Song { get; set; }
        public string AlbumId { get; set; }
    }
}
