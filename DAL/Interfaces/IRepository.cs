using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        List<T> GetList(); //получение списка всех объектов
        T GetItem(int id); // получение одного объекта по id 
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
    }
}
