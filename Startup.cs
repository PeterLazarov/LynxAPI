using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Data;
using Models;
using Services;

namespace API
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
            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DatabaseString")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<DataContext>();
            // ConfigureAuthentication(services);

            services.AddControllers();

            services.AddScoped<IProvinceImporter, ProvinceImporter>();
            services.AddScoped<IRegionImporter, RegionImporter>();
            services.AddScoped<IPatientImporter, PatientImporter>();
            services.AddScoped<ICaseUpdateImporter, CaseUpdateImporter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => {
                options.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
            });

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // #region Private members
        // private ConfigureAuthentication(IServiceCollection services) {
        //     services.AddAuthentication(options =>
        //         {
        //             options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //             options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        //             options.DefaultChallengeScheme = "LynxTrial";
        //         })
        //         .AddCookie()
        //         .AddOAuth("LynxTrial", options =>
        //         {
        //             options.ClientId = Configuration["LynxTrial:ClientId"];
        //             options.ClientSecret = Configuration["LynxTrial:ClientSecret"];
        //             options.CallbackPath = new PathString("/signin-lynxtrial");

        //             options.AuthorizationEndpoint = "localhost:3000/login/oauth/authorize";
        //             options.TokenEndpoint = "localhost:3000/login/oauth/access_token";
        //             options.UserInformationEndpoint = "https://localhost:5001/api/user";

        //             options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
        //             options.ClaimActions.MapJsonKey(ClaimTypes.Name, "username");

        //             options.Events = new OAuthEvents
        //             {
        //                 OnCreatingTicket = async context =>
        //                 {
        //                     var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
        //                     request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //                     request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

        //                     var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
        //                     response.EnsureSuccessStatusCode();

        //                     var user = JObject.Parse(await response.Content.ReadAsStringAsync());

        //                     context.RunClaimActions(user);
        //                 }
        //             };
        //         });
        // }
        // #endregion
    }
}
