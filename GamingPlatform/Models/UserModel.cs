using BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingPlatform.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        public int id;
        public int? messageId;
        public int userTypeId;
        public string nickname;
        public DateTime? birthday;
        public string email;
        public string password;
        public decimal balance;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public int? MessageId
        {
            get { return messageId; }
            set
            {
                messageId = value;
                OnPropertyChanged("MessageId");
            }
        }
        public int UserTypeId
        {
            get { return userTypeId; }
            set
            {
                userTypeId = value;
                OnPropertyChanged("UserTypeId");
            }
        }
        public string Nickname
        {
            get { return nickname; }
            set
            {
                nickname = value;
                OnPropertyChanged("Nickname");
            }
        }
        public DateTime? Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public decimal Balance
        {
            get { return balance; }
            set
            {
                balance = value;
                OnPropertyChanged("Balance");
            }
        }

        public UserModel() { }

        public UserModel(UserDTO user)
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
