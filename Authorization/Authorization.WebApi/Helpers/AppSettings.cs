using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authorization.WebApi.Helpers
{
    /// <summary>
    /// Набор настроек из appSetting.json
    /// </summary>
    public class AppSettings
    {
        public string Secret { get; set; }

        public string Audience { get; set; }

        public  string Issuer { get; set; }

        public string Domain { get; set; }

        public int  DaysValid { get; set; }
    }
}
