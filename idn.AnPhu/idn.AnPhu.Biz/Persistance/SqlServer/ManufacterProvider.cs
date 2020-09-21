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
    public class ManufacterProvider : DataAccessBase, IManufacterProvider
    {
        public void Add(Manufacters item)
        {
            var com = this.GetCommand("Sp_Manufacters_Create");
            if (com == null) return;
            com.AddParameter<string>(this.Factory, "ManufactName", item.ManufactName);
            com.AddParameter<string>(this.Factory, "ManufactShortName", item.ManufactShortName);
            com.AddParameter<bool>(this.Factory, "IsActive", item.IsActive);
            com.AddParameter<string>(this.Factory, "Culture", item.Culture);
            com.AddParameter<string>(this.Factory, "CreateBy", item.CreateBy);
            com.SafeExecuteNonQuery();

        }
        public Manufacters Get(Manufacters dummy)
        {
            var comm = this.GetCommand("Sp_Manufacters_Get");
            if (comm == null) return null;
            comm.AddParameter<int>(this.Factory, "ManufactId", dummy.ManufactId);
            var dt = this.GetTable(comm);
            var item = EntityBase.ParseListFromTable<Manufacters>(dt).FirstOrDefault();
            return item ?? null;
        }
        public List<Manufacters> GetAll(int startIndex, int count, ref int totalItems)
        {
            throw new NotImplementedException();
        }
        public List<Manufacters> GetAll(string culture)
        {
            var comm = this.GetCommand("Sp_Manufacters_GetAll");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Manufacters>(dt);

        }
        public List<Manufacters> GetAllActive(string culture)
        {
            var comm = this.GetCommand("Sp_Manufacters_GetAllActive");
            if (comm == null) return null;
            comm.AddParameter<string>(this.Factory, "Culture", culture);
            var dt = this.GetTable(comm);
            return EntityBase.ParseListFromTable<Manufacters>(dt);
        }
        public void Remove(Manufacters item)
        {
            var comm = this.GetCommand("Sp_Manufacters_Delete");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ManufactId", item.ManufactId);
            comm.SafeExecuteNonQuery();
        }
        public void Update(Manufacters @new, Manufacters old)
        {
            var model = @new;
            var comm = this.GetCommand("Sp_Manufacters_Update");
            if (comm == null) return;
            comm.AddParameter<int>(this.Factory, "ManufactId", old.ManufactId);
            comm.AddParameter<string>(this.Factory, "ManufactName", model.ManufactName);
            comm.AddParameter<string>(this.Factory, "ManufactShortName", model.ManufactShortName);
            comm.AddParameter<bool>(this.Factory, "IsActive", model.IsActive);
            comm.SafeExecuteNonQuery();

        }
    }
}
