using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApiRouter.Models;
using Polly;
using Microsoft.EntityFrameworkCore;
using WebApiRouter.Services;
using UserRightsValidation;
using Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Db.Authorization;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace WebApiRouter
{
    public class Startup
    {
        private readonly string _originUrl;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _originUrl = Configuration.GetSection("OriginUrl").Value;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            services.Configure<UrlConfig>(Configuration);
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins(_originUrl)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
            services.AddDbContext<EntitiesContext>(options =>
            {

                //options.UseSqlServer(Configuration.GetConnectionString("Pstgr"),
                //    sqlServerOptions => sqlServerOptions.MigrationsAssembly(typeof(EntitiesContext).Assembly.FullName));
                options.UseNpgsql(Configuration.GetConnectionString("Pstgr"),
                    npsqlOptions => npsqlOptions.MigrationsAssembly("Authorization.WebApi"));
            }
            );

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true; // false by default
                //options.InputFormatters.Insert(0,new XDocumentInputFormatter());
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddControllers();
            services.AddHttpClient<IAuthorizationClientService, AuthorizationClientService>();
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
            services.AddTransient<IAuthorizationPolicyProvider, AuthorizationCustomPolicy>();
            services.AddTransient<IAuthorizationHandler, ModuleHandler>();
            services.AddTransient<IAuthorizationHandler, PermissionHandler>();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Api Router", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api Router v1");
                c.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(
            (builder =>
            {
                builder.WithOrigins(_originUrl)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
            //app.Use((context, next) =>
            //{
            //   context.Response.Headers.Add("Content-Type", "application/xml ,application/json");
            //   return next.Invoke();
            //});
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();     
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
