using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ModeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ModeDTO() { }

        public ModeDTO(Mode mode)
        {
            Id = mode.Id;
            Name = mode.Name;
        }
    }
}
