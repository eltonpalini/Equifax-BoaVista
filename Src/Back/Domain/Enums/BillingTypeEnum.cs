using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum BillingTypeEnum : int
    {
        [EnumMember(Value ="Assinatura")]
        Subscription = 1,

        [EnumMember(Value = "One time")]
        OnDemand = 2
    }
}
