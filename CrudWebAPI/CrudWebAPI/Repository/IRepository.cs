using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudWebAPI.Models;

namespace CrudWebAPI.Repository
{
    // Interface to declare the type of resource reposiroty will hold and the operations on it
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllItems();
        T GetItemById(int id);
        T AddItem(T item);
        bool RemoveItem(int id);
        T UpdateItem(T item);
    }
}
