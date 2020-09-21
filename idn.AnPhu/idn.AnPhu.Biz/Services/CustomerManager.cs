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
    public class CustomerManager : DataManagerBase<Customer>
    {
        public CustomerManager() : base() { }
        public CustomerManager(IDataProvider<Customer> provider) : base(provider) { }

        private ICustomerProvider CustomerProvider
        {
            get { return (ICustomerProvider)Provider; }
        }
        public List<Customer> GetAll()
        {
            return CustomerProvider.GetAll();
        }
        public List<Customer> GetAllActive()
        {
            return CustomerProvider.GetAllActive();
        }
        public Customer GetByPhone(string phone)
        {
            return CustomerProvider.GetByPhone(phone);
        }
        public bool Delete(int id)
        {
            return CustomerProvider.Delete(id);
        }
    }
}
