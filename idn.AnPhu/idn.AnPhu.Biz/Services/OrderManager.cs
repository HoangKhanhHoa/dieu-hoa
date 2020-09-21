using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class OrderManager : DataManagerBase<Order>
    {
        public OrderManager() : base() { }
        public OrderManager(IDataProvider<Order> provider) : base(provider) { }

        private IOrderProvider OrderProvider
        {
            get { return (IOrderProvider)Provider; }
        }
        public List<Order> GetAll()
        {
            return OrderProvider.GetAll();
        }
        public List<Order> FilterByIsActive()
        {
            return OrderProvider.FilterByIsActive();
        }
        public int GetLastId()
        {
            return OrderProvider.GetLastId();
        }
        public bool Delete(int orderid)
        {
            return OrderProvider.Delete(orderid);
        }
    }
}
