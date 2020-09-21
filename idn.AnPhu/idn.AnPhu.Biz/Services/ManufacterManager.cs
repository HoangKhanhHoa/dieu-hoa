using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.SqlServer
{
    public class ManufacterManager : DataManagerBase<Manufacters>
    {
        public ManufacterManager() : base() { }
        public ManufacterManager(IDataProvider<Manufacters> provider) : base(provider) { }

        private IManufacterProvider ManufacterProvider
        {
            get { return (IManufacterProvider)Provider; }
        }
        public List<Manufacters> GetAll(string lang)
        {
            return ManufacterProvider.GetAll(lang);
        }
        public List<Manufacters> GetAllActive(string lang)
        {
            return ManufacterProvider.GetAllActive(lang);
        }
    }
}
