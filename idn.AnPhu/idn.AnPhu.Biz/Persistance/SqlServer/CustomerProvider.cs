using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class CustomerProvider : DataAccessBase, ICustomerProvider
    {
        public void Add(Customer item)
        {
            var comm = this.GetCommand("Sp_Customer_Create");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "Name", item.Name);
            comm.AddParameter<string>(this.Factory, "Address", item.Address);
            comm.AddParameter<string>(this.Factory, "Email", item.Email);
            comm.AddParameter<string>(this.Factory, "Phone", item.Phone);
            comm.AddParameter<string>(this.Factory, "Username", item.UserName);
            comm.AddParameter<string>(this.Factory, "Password", item.Password);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);

            comm.SafeExecuteNonQuery();
        }
        public bool Delete(int id)
        {
            var comm = this.GetCommand("Sp_Customer_Delete");
            if (comm == null) return false;
            comm.AddParameter<int>(this.Factory, "CustomerId", id);

            if (comm.SafeExecuteNonQuery() != 0)
            {
                return true;
            }
            return false;
        }
        public Customer Get(Customer dummy)
        {
            var comm = this.GetCommand("Sp_Customer_Get");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "CustomerId", dummy.CustomerId);

            var dt = this.GetTable(comm);
            var item = EntityBase.ParseListFromTable<Customer>(dt).FirstOrDefault();
            return item ?? null;
        }
        public List<Customer> GetAll()
        {
            var comm = this.GetCommand("Sp_Customer_GetAll");
            if (comm == null) return null;
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Customer>(dt);
        }
        public List<Customer> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }
        public List<Customer> GetAllActive()
        {
            var comm = this.GetCommand("Sp_Customer_GetAllActive");
            if (comm == null) return null;
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Customer>(dt);
        }
        public Customer GetByPhone(string phone)
        {
            var comm = this.GetCommand("Sp_Customer_GetByPhone");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Phone", phone);

            var dt = this.GetTable(comm);
            var item = EntityBase.ParseListFromTable<Customer>(dt).FirstOrDefault();
            return item ?? null;
        }
        public void Remove(Customer item)
        {
            var comm = this.GetCommand("Sp_Customer_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "CustomerId", item.CustomerId);

            comm.SafeExecuteNonQuery();
        }
        public void Update(Customer @new, Customer old)
        {
            var item = @new;
            var comm = this.GetCommand("Sp_Customer_Update");
            if (comm == null) return;

            comm.AddParameter<int>(this.Factory, "CustomerId", old.CustomerId);
            comm.AddParameter<string>(this.Factory, "Name", item.Name);
            comm.AddParameter<string>(this.Factory, "Address", item.Address);
            comm.AddParameter<string>(this.Factory, "Email", item.Email);
            comm.AddParameter<string>(this.Factory, "Phone", item.Phone);
            comm.AddParameter<string>(this.Factory, "Username", item.UserName);
            comm.AddParameter<string>(this.Factory, "Password", item.Password);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);

            comm.SafeExecuteNonQuery();
        }
    }
}
