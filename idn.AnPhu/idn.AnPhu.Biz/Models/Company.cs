using Client.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idn.AnPhu.Biz.Models
{
    public class Company : EntityBase
    {
        [DataColum]
        public int CompanyId { get; set; }

        [DataColum]
        public string CompanyName { get; set; }

        [DataColum]
        public string CompanyAddress { get; set; }

        [DataColum]
        public string CompanyPhone { get; set; }

        [DataColum]
        public string CompanyHotline { get; set; }

        [DataColum]
        public string CompanyTimework { get; set; }

        [DataColum]
        public int ParentId { get; set; }

        [DataColum]
        public bool IsActive { get; set; }

        [DataColum]
        public DateTime CreateDate { get; set; }

        [DataColum]
        public DateTime UpdateDate { get; set; }

        [DataColum]
        public string CreateBy { get; set; }
    }
}
