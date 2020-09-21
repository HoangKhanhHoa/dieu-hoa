using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class OrderProvider: DataAccessBase, IOrderProvider
    {
        public void Add(Order item)
        {
            var comm = this.GetCommand("Sp_Order_Create");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "CustomerId", item.CustomerId);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<decimal>(this.Factory, "TotalMoney", item.ToTalMoney);
            comm.SafeExecuteNonQuery();
        }
        public bool Delete(int orderid)
        {
            var comm = this.GetCommand("Sp_Order_Delete");
            if (comm == null) return false;
            comm.AddParameter<int>(this.Factory, "OrderId", orderid);

            if (comm.SafeExecuteNonQuery() != 0)
            {
                return true;
            }
            return false;
        }
        public List<Order> FilterByIsActive()
        {
            var comm = this.GetCommand("Sp_Order_GetByIsActive");
            if (comm == null) return null;
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Order>(dt);
        }
        public Order Get(Order dummy)
        {
            var comm = this.GetCommand("Sp_Order_Get");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "OrderId", dummy.OrderId);
            var dt = this.GetTable(comm);
            var item = EntityBase.ParseListFromTable<Order>(dt).FirstOrDefault();
            return item ?? null;

        }
        public List<Order> GetAll()
        {
            var comm = this.GetCommand("Sp_Order_GetAll");
            if (comm == null) return null;
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Order>(dt);
        }
        public List<Order> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }
        public int GetLastId()
        {
            var comm = this.GetCommand("Sp_Get_LastOrderId");
            var dt = this.GetTable(comm);
            int id = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                id = dt.Rows[i].Field<int>("LastId");
            }
            return id;
        }
        public void Remove(Order item)
        {
            throw new NotImplementedException();
        }

        public void Update(Order @new, Order old)
        {
            var item = @new;
            var comm = this.GetCommand("Sp_Order_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "OrderId", old.OrderId);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<decimal>(this.Factory, "ToTalMoney", item.ToTalMoney);

            comm.SafeExecuteNonQuery();
        }
    }
}
