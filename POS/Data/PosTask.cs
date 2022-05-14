using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Data
{
    public class PosTask
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public decimal AmountInMachineBefore { get; set; }
        public decimal AmountInCashBefore { get; set; }

        public decimal AmountInMachineAfter { get; set; }
        public decimal AmountInCashAfter { get; set; }

        public decimal TotalCharges { get; set; }
        public decimal MoniePointCharges { get; set; }
        public decimal CityCharges { get; set; }

        public decimal Admin_Pay { get; set; }
        public decimal Rep_Pay { get; set; }
        public decimal Machine_Pay { get; set; }

        public bool Close { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public ICollection<Activity> Activities { get; set; }
        public virtual Expenditure Expenditure { get; set; }
    }
}
