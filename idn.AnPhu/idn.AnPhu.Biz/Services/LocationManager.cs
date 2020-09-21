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
    public class LocationManager : DataManagerBase<Location>
    {
        public LocationManager() : base() { }
        public LocationManager(IDataProvider<Location> provider) : base(provider) { }

        private ILocationProvider LocationProvider
        {
            get { return (ILocationProvider)Provider; }
        }
        public List<Location> GetAllByParentId(int id)
        {
            return LocationProvider.GetAllByParentId(id);
        }
        public List<Location> GetAllActiveByParentId(int id)
        {
            return LocationProvider.GetAllActiveParentId(id);
        }
    }
}
