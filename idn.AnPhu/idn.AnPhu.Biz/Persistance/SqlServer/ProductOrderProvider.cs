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
    public class ProductOrderProvider : DataAccessBase, IProductOrderProvider
    {
        public void Add(ProductOrder item)
        {
            var comm = this.GetCommand("Sp_ProductOrder_Create");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "OrderId", item.OrderId);
            comm.AddParameter<int>(this.Factory, "ProductId", item.ProductId);
            comm.AddParameter<int>(this.Factory, "Quantity", item.Quantity);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);

            comm.SafeExecuteNonQuery();
        }
        public bool Delete_Detail(int proid, int orderid)
        {
            var comm = this.GetCommand("Sp_Order_Detail_Delete");
            if (comm == null) return false;
            comm.AddParameter<int>(this.Factory, "OrderId", orderid);
            comm.AddParameter<int>(this.Factory, "ProductId", proid);

            if (comm.SafeExecuteNonQuery() != 0)
            {
                return true;
            }
            return false;
        }
        public ProductOrder Get(ProductOrder dummy)
        {
            throw new NotImplementedException();
        }
        public List<ProductOrder> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }
        public List<ProductOrder> GetByOrderId(int id)
        {
            var comm = this.GetCommand("Sp_Order_GetDetail");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "OrderId", id);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<ProductOrder>(dt);
        }

        public void Remove(ProductOrder item)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductOrder @new, ProductOrder old)
        {
            throw new NotImplementedException();
        }
    }
}
