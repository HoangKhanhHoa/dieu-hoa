using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IProductOrderProvider : IDataProvider<ProductOrder>
    {
        List<ProductOrder> GetByOrderId(int id);
        bool Delete_Detail(int proid, int orderid);
    }
}
