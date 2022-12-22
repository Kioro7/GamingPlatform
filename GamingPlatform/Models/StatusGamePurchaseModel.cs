﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamingPlatform.Models
{
    public class StatusGamePurchaseModel : INotifyPropertyChanged
    {
        private int id;
        private string name;

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

        public StatusGamePurchaseModel() { }

        public StatusGamePurchaseModel(StatusGamePurchaseDTO status)
        {
            Id = status.Id;
            Name = status.Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
