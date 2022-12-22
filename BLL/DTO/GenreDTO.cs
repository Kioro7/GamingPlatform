using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GenreDTO
    {
        public int GenreId { get; set; }

        public string GenreName { get; set; }

        public GenreDTO() { }

        public GenreDTO(Genre genre)
        {
            GenreId = genre.Id;
            GenreName = genre.Name;
        }
    }
}
