namespace DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Message()
        {
            User2 = new HashSet<User>();
        }

        public int SenderId { get; set; }

        public int ReceiveId { get; set; }

        public int MessageId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Text { get; set; }

        [Column(TypeName = "date")]
        public DateTime DepartureDate { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> User2 { get; set; }
    }
}
