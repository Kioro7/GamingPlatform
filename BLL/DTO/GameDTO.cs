using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entities;

namespace BLL.DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int ModeId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string Developer { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public int NumberRatings { get; set; }

        public GameDTO() { }

        public GameDTO (Game g)
        {
            Id = g.Id;
            Name = g.Name;
            GenreId = g.GenreId;
            ModeId = g.ModeId;
            ReleaseDate = (DateTime)g.ReleaseDate;
            RegistrationDate = g.RegistrationDate;
            Developer = g.Developer;
            Price = g.Price;
            ImageLink = g.ImageLink;
            Description = g.Description;
            Rating = g.Rating;
            NumberRatings = g.NumberRatings;
        }
    }
}
