using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IOrderProvider : IDataProvider<Order>
    {
        List<Order> GetAll();
        List<Order> FilterByIsActive();
        int GetLastId();
        bool Delete(int orderid);
    }
}
