using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int? MessageId { get; set; }
        public int UserTypeId { get; set; }
        public string Nickname { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Balance { get; set; }

        public UserDTO() { }

        public UserDTO(User user)
        {
            Id = user.Id;
            MessageId = user.MessageId;
            UserTypeId = user.UserTypeId;
            Nickname = user.Nickname;
            Birthday = user.Birthday;
            Email = user.Email;
            Password = user.Password;
            Balance = user.Balance;
        }
    }
}
