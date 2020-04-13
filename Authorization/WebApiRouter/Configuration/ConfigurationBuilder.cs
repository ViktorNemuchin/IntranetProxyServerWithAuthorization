using Db.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories.UserRepository;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using UserRightsValidation;
using WebApiRouter.Models;
using WebApiRouter.Services;

namespace WebApiRouter.Configuration
{
    public class ConfigurationBuilder
    {
        public IConfiguration Configuration;

        public ConfigurationBuilder(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://pozaim_testservices:809", "http://localhost:8080")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
            services.AddDbContext<EntitiesContext>(options =>
            {

                //options.UseSqlServer(Configuration.GetConnectionString("Pstgr"),
                //    sqlServerOptions => sqlServerOptions.MigrationsAssembly(typeof(EntitiesContext).Assembly.FullName));
                options.UseNpgsql(Configuration.GetConnectionString("Pstgr"));
            }
            );


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
            services.AddHttpClient<IAuthorizationClientService, AuthorizationClientService>();
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            services.Configure<UrlConfig>(Configuration);
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.UTF8.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        RequireExpirationTime = true,
                        ValidAudience = appSettings.Audience,
                        ValidIssuer = appSettings.Issuer
                    };
                });
            services.AddScoped<IUserToken, UserToken>();
            services.AddScoped<IAuthorizationPolicyProvider, AuthorizationCustomPolicy>();
            services.AddScoped<IAuthorizationHandler, ModuleHandler>();
            services.AddScoped<IAuthorizationHandler, PermissionHandler>();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Api Router", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }
    }
}
