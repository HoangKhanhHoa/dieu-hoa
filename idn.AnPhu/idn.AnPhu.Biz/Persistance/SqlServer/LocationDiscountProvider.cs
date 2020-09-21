using Client.Core.Data.DataAccess;
using Client.Core.Data.Entities;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using idn.AnPhu.Constants;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class LocationDiscountProvider : DataAccessBase, ILocationDiscountProvider
    {
        public LocationDiscount Get(LocationDiscount dummy)
        {
            var comm = this.GetCommand("Sp_LocationDiscount_Get");
            if (comm == null)
            {
                return null;
            }
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", dummy.LocationDiscountId);
            var dt = this.GetTable(comm);
            var sliderBanner = EntityBase.ParseListFromTable<LocationDiscount>(dt).FirstOrDefault();
            return sliderBanner ?? null;
        }
        public void Add(LocationDiscount item, string culture)
        {
            //var comm = this.GetCommand("Sp_LocationDiscount_Create");
            //if (comm == null) return;
            //comm.AddParameter<string>(this.Factory, "LocationDiscountName", item.LocationDiscountName);
            //comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            //comm.AddParameter<string>(this.Factory, "Culture", culture);
            //comm.AddParameter<string>(this.Factory, "LocationDiscountValue", item.LocationDiscountValue);
            //comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            //comm.AddParameter<string>(this.Factory, "Note", item.Note);
            //comm.SafeExecuteNonQuery();
        }
        public void Add(LocationDiscount item)
        {
            var comm = this.GetCommand("Sp_LocationDiscount_Create");
            if (comm == null) return;
            comm.AddParameter<string>(this.Factory, "LocationDiscountName", item.LocationDiscountName);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Culture", item.Culture);
            comm.AddParameter<string>(this.Factory, "LocationDiscountValue", item.LocationDiscountValue);
            comm.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);
            comm.SafeExecuteNonQuery();
        }
        public void Update(LocationDiscount @new, LocationDiscount old)
        {
            var item = @new;
            item.LocationDiscountId = old.LocationDiscountId;
            var comm = this.GetCommand("Sp_LocationDiscount_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
            comm.AddParameter<string>(this.Factory, "LocationDiscountName", item.LocationDiscountName);
            comm.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            comm.AddParameter<string>(this.Factory, "Note", item.Note);
            comm.AddParameter<string>(this.Factory, "LocationDiscountValue", item.LocationDiscountValue);
            comm.SafeExecuteNonQuery();
        }
        public void Remove(LocationDiscount item)
        {
            var comm = this.GetCommand("Sp_LocationDiscount_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "LocationDiscountId", item.LocationDiscountId);
            comm.SafeExecuteNonQuery();
        }
        public List<LocationDiscount> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }
        public List<LocationDiscount> GetAll(string culture)
        {
            var comm = this.GetCommand("Sp_LocationDiscount_GetAll");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<LocationDiscount>(dt);
        }
        public List<LocationDiscount> GetAllActive(string culture)
        {
            var comm = this.GetCommand("Sp_LocationDiscount_GetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<LocationDiscount>(dt);
        }
    }
}
