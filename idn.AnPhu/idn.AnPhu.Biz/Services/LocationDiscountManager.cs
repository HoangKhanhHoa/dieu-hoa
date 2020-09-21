using Client.Core.Data;
using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Services
{
    public class LocationDiscountManager : DataManagerBase<LocationDiscount>
    {
        public LocationDiscountManager()
            : base()
        { }

        public LocationDiscountManager(IDataProvider<LocationDiscount> provider)
            : base(provider)
        { }

        private ILocationDiscountProvider LocationDiscountProvider
        {
            get { return (ILocationDiscountProvider)Provider; }
        }

        public List<LocationDiscount> GetAll(string culture)
        {
            return LocationDiscountProvider.GetAll(culture);
        }
        public List<LocationDiscount> GetAllActive(string culture)
        {
            return LocationDiscountProvider.GetAllActive(culture);
        }
    }
}
