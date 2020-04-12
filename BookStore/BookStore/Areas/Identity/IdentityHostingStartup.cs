using System;
using BookStore.Areas.Identity.Data;
using BookStore.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using Microsoft.Extensions.Options;

[assembly: HostingStartup(typeof(BookStore.Areas.Identity.IdentityHostingStartup))]
namespace BookStore.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UserAuthDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UserAuthDBContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;

                })
                    .AddEntityFrameworkStores<UserAuthDBContext>();

                
            });


        }
    }
}