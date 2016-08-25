using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsole
{
    public class Initializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            context.PayWays.AddRange(new List<PayWay>
            {
                new PayWay {Name = "Alipay" },
                new PayWay {Name = "WeChat" },
                new PayWay {Name = "QQhongbao"}
            });
        }
    }
}
