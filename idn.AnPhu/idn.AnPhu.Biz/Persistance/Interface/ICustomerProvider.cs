using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface ICustomerProvider : IDataProvider<Customer>
    {
        List<Customer> GetAll();
        List<Customer> GetAllActive();
        Customer GetByPhone(string phone);
        bool Delete(int id);
    }
}
