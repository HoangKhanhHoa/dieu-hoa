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
    public class LocationProvider : DataAccessBase, ILocationProvider
    {
        public Location Get(Location dummy)
        {
            var comm = this.GetCommand("Sp_Location_Get");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "LocationId", dummy.LocationId);
            var dt = this.GetTable(comm);
            var item = EntityBase.ParseListFromTable<Location>(dt).FirstOrDefault();
            return item ?? null;
        }

        public void Add(Location item)
        {
            var comm = this.GetCommand("Sp_Location_Create");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
            comm.AddParameter<string>(this.Factory, "LocationName", item.LocationName);
            comm.AddParameter<string>(this.Factory, "LocationValue", item.LocationValue);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Culture", item.Culture);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);

            comm.SafeExecuteNonQuery();
        }
        public List<Location> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }
        public void Remove(Location item)
        {
            var comm = this.GetCommand("Sp_Location_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LocationId", item.LocationId);

            comm.SafeExecuteNonQuery();
        }

        public void Update(Location @new, Location old)
        {
            var item = @new;
            var comm = this.GetCommand("Sp_Location_Update");
            if (comm == null) return;

            comm.AddParameter<int>(this.Factory, "LocationId", item.LocationId);
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
            comm.AddParameter<string>(this.Factory, "LocationName", item.LocationName);
            comm.AddParameter<string>(this.Factory, "LocationValue", item.LocationValue);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);
            comm.AddParameter<string>(this.Factory, "Culture", item.Culture);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);

            comm.SafeExecuteNonQuery();
        }

        public List<Location> GetAllActiveParentId(int id)
        {
            var comm = this.GetCommand("Sp_Location_GetAllActiveByParentId");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", id);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Location>(dt);
        }

        public List<Location> GetAllByParentId(int id)
        {
            var comm = this.GetCommand("Sp_Location_GetAllByParentId");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", id);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Location>(dt);
        }
    }
}
