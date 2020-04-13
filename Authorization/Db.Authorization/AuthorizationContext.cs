using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Core.Configuration.Base.Extensions;
using Core.Data.Base;

namespace Db.Authorization
{
    class AuthorizationContext: CoreDbContext
    {
        public DbContextOptions AuthContOptions() 
        {
            var conf = Core.Configuration.ConfigurationFactory.GetJsonConfig();
            var setting = conf.GetDbConfiguration(Core.Configuration.Base.DbInstanceType.pgsInfinity);
            var dbOptions = Core.Data.Base.DataProviderFactory.GetContextOptions(setting);

            return dbOptions;
        }

        public AuthorizationContext(DbContextOptions<CoreDbContext> options)
          
        {

            DbContextOptions settings = AuthContOptions();
            options = settings;
        }
    }
}
