using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface ILocationProvider : IDataProvider<Location>
    {
        List<Location> GetAllByParentId(int id);
        List<Location> GetAllActiveParentId(int id);
    }
}
