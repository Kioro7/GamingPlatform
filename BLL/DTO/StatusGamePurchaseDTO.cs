using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class StatusGamePurchaseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public StatusGamePurchaseDTO() { }

        public StatusGamePurchaseDTO(StatusGamePurchase status)
        {
            Id = status.Id;
            Name = status.Name;
        }
    }
}
