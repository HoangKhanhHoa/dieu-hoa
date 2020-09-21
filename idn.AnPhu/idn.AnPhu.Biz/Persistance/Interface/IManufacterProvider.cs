using Client.Core.Data;
using idn.AnPhu.Biz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Persistance.Interface
{
    public interface IManufacterProvider : IDataProvider<Manufacters>
    {
        List<Manufacters> GetAll(string culture);
        List<Manufacters> GetAllActive(string culture);
    }
}
