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
    public class ProductOrderManager : DataManagerBase<ProductOrder>
    {
        public ProductOrderManager() : base() { }
        public ProductOrderManager(IDataProvider<ProductOrder> provider) : base(provider) { }

        private IProductOrderProvider ProductOrderProvider
        {
            get { return (IProductOrderProvider)Provider; }
        }
        public List<ProductOrder> GetByOrderId(int id)
        {
            return ProductOrderProvider.GetByOrderId(id);
        }
        public bool Delete_Detail(int proid, int orderid)
        {
            return ProductOrderProvider.Delete_Detail(proid, orderid);
        }
    }
}
