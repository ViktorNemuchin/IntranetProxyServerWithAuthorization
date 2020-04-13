using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Core.Data;
using Core.Data.Base;
using Core.Configuration.Base.Extensions;

namespace Db.Authorization
{
    public static class SettingsGenerator
    {
        public static string AuthContOptions()
        {
            var conf = Core.Configuration.ConfigurationFactory.GetJsonConfig();
            var setting = conf.GetDbConfiguration(Core.Configuration.Base.DbInstanceType.Default);
            var connectionString = Core.Data.Base.DataProviderFactory.GetContextString(setting);

            return connectionString;
        }
    }
}
