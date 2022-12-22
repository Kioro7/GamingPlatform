namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GamePurchase")]
    public partial class GamePurchase
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }

        public int StatusBuyId { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "money")]
        public decimal PurchasePrice { get; set; }

        public virtual Game Game { get; set; }

        public virtual StatusGamePurchase StatusGamePurchase { get; set; }

        public virtual User User { get; set; }
    }
}
