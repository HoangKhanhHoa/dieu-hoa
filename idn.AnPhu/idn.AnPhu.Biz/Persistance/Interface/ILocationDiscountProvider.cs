using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface ILocationDiscountProvider : IDataProvider<LocationDiscount>
    {
        List<LocationDiscount> GetAll(string culture);
        List<LocationDiscount> GetAllActive(string culture);
    }
}
