namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            GamePurchase = new HashSet<GamePurchase>();
            Statistics = new HashSet<Statistics>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public int GenreId { get; set; }

        public int ModeId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [StringLength(50)]
        public string Developer { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [Required]
        [StringLength(200)]
        public string ImageLink { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public float Rating { get; set; }

        public int NumberRatings { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual Mode Mode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GamePurchase> GamePurchase { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Statistics> Statistics { get; set; }
    }
}
