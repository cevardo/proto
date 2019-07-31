using AspNet.Security.OpenIdConnect.Primitives;
using AutoMapper;
using Embily.Gateways;
using Embily.Models;
using Embily.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using System;

namespace EmbilyAdmin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var env = Configuration["ASPNETCORE_ENVIRONMENT"];

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //services.AddMemoryCache();

            services.AddAutoMapper();

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    // handle loops correctly
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

                    // use standard name conversion of properties
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

                    //Default DateFormat
                    options.SerializerSettings.DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
                });

            //var cannectiionString, check if Mac or Windows -- 
            var connectionString = Environment.OSVersion.Platform == PlatformID.Unix ? "EmbilyDatabaseUnix" : "EmbilyDatabase";
            var connection = Configuration.GetConnectionString(connectionString);
            services.AddDbContext<EmbilyDbContext>(options =>
            {
                options.UseSqlServer(connection);
                options.UseOpenIddict();
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(config =>
            {
                config.SignIn.RequireConfirmedEmail = true;
            })
            .AddEntityFrameworkStores<EmbilyDbContext>()
            .AddDefaultTokenProviders();

            // Configure Identity to use the same JWT claims as OpenIddict instead
            // of the legacy WS-Federation claims it uses by default (ClaimTypes),
            // which saves you from doing the mapping in your authorization controller.
            services.Configure<IdentityOptions>(options =>
            {
                options.ClaimsIdentity.UserNameClaimType = OpenIdConnectConstants.Claims.Name;
                options.ClaimsIdentity.UserIdClaimType = OpenIdConnectConstants.Claims.Subject;
                options.ClaimsIdentity.RoleClaimType = OpenIdConnectConstants.Claims.Role;
            });

            // Register the OpenIddict services.
            // Note: use the generic overload if you need
            // to replace the default OpenIddict entities.
            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                        .UseDbContext<EmbilyDbContext>();
                })
                .AddServer(options =>
                {
                    options.UseMvc();

                    // Enable the authorization and token endpoints (required to use the code flow).
                    options.EnableTokenEndpoint("/connect/token");

                    options.AllowPasswordFlow();
                    options.AllowRefreshTokenFlow();

                    // Accept anonymous clients (i.e clients that don't send a client_id).
                    options.AcceptAnonymousClients();

#if DEBUG
                    options.DisableHttpsRequirement();
#endif
                    options.RegisterScopes(
                        OpenIdConnectConstants.Scopes.OpenId,
                        OpenIdConnectConstants.Scopes.Email,
                        OpenIdConnectConstants.Scopes.Phone,
                        OpenIdConnectConstants.Scopes.Profile,
                        OpenIdConnectConstants.Scopes.OfflineAccess
                    );

                    options.SetAccessTokenLifetime(TimeSpan.FromDays(30));
                })
                .AddValidation();

            // app services
            services.AddTransient<IEmailQueueSender, EmailQueueSender>();
            services.AddTransient<IRefGen, RefGenerator>();
            services.AddTransient<IMapper, Mapper>();

            services.AddTransient<ICardHolder, KoKardCard>();

            if (env == "Development")
            {
                services.AddTransient<ICryptoAddress, CryptoAddressCreatorSim>();
            }
            else
            {
                services.AddTransient<ICryptoAddress, CryptoAddressCreator>();
            }

            if (env == "Production")
            {
                services.AddTransient<ICardLoad, KoKardCard>();
            }
            else
            {
                services.AddTransient<ICardLoad, VirtualCard>();
            }

            // database support
            services.AddTransient<IEmbilyDbInitializer, EmbilyDbInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration, IEmbilyDbInitializer embilyDbInitializer)
        {
            if (!env.IsDevelopment())
            {
                var options = new RewriteOptions().AddRedirectToHttps();
                app.UseRewriter(options);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    if (Convert.ToBoolean(configuration["RunAsProxy"]))
                    {
                        // start ng web server from PowerShell:
                        // > cd ClientApp 
                        // > ng serve 
                        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200"); // Use this instead to use the angular cli server
                    }
                    else
                    {
#if DEBUG
                        spa.UseAngularCliServer(npmScript: "start");
#else
                        spa.UseAngularCliServer(npmScript: "release");
#endif
                        spa.Options.StartupTimeout = TimeSpan.FromSeconds(60); // Increase the timeout if angular app is taking longer to startup
                    }
                }
            });


            if (!env.IsProduction())
            {
                embilyDbInitializer.SeedAsync().Wait();
            }
        }
    }
}
