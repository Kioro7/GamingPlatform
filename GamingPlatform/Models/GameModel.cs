using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace GamingPlatform.Models
{
    public class GameModel : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private int genreId;
        private string genreName;
        private int modeId;
        private DateTime releaseDate;
        private decimal price;
        private string developer;
        private DateTime registrationDate;
        private string fileName;
        public BitmapImage imageLink;
        private string description;
        private float rating;
        public int numberRatings;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public int GenreId
        {
            get { return genreId; }
            set
            {
                genreId = value;
                OnPropertyChanged("GenreId");
            }
        }
        public string GenreName
        {
            get { return genreName; }
            set
            {
                genreName = value;
                OnPropertyChanged("GenreName");
            }
        }
        public int ModeId
        {
            get { return modeId; }
            set
            {
                modeId = value;
                OnPropertyChanged("ModeId");
            }
        }
        public DateTime ReleaseDate
        {
            get { return releaseDate; }
            set
            {
                releaseDate = value;
                OnPropertyChanged("ReleaseDate");
            }
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }
        public string Developer
        {
            get { return developer; }
            set
            {
                developer = value;
                OnPropertyChanged("Developer");
            }
        }
        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set
            {
                registrationDate = value;
                OnPropertyChanged("RegistrationDate");
            }
        }
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                OnPropertyChanged("FileName");
            }
        }
        public string ImageLink { get; set; }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        public float Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                OnPropertyChanged("Rating");
            }
        }
        public int NumberRatings
        {
            get { return numberRatings; }
            set
            {
                numberRatings = value;
                OnPropertyChanged("NumberRatings");
            }
        }

        public GameModel() { }

        public GameModel(GameDTO game, List<GenreModel> genre)
        {
            Id = game.Id;
            Name = game.Name;
            GenreId = game.GenreId;
            GenreName = genre.Where(i => i.Id == game.GenreId).FirstOrDefault().Name;
            ModeId = (int)game.ModeId;
            ReleaseDate = (DateTime)game.ReleaseDate;
            Price = game.Price;
            Developer = game.Developer;
            RegistrationDate = game.RegistrationDate;
            FileName = "/Resources/" + Name + ".jpg";
            Description = game.Description;
            Rating = game.Rating;
            NumberRatings = game.NumberRatings;

            BitmapImage imageLink = new BitmapImage();
            imageLink.UriSource = new Uri(game.ImageLink, UriKind.RelativeOrAbsolute);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
