using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class Manufacters : EntityBase
    {
        [DataColum]
        public int ManufactId { get; set; }

        [DataColum]
        public string ManufactName { get; set; }

        [DataColum]
        public string ManufactShortName { get; set; }

        [DataColum]
        public string CreateBy { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public string Culture { get; set; }
    }
}
