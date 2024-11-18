using DataAccessLayer.DataContexts;
using MediatR;
using Application;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Presentation.AppCode.DI;
using Presentation.AppCode.Pipeline;
using Application.Services;
using Infrastructure.Abstracts;
using Infrastructure.Configurations;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Host.UseServiceProviderFactory(new NFTMarketplaceServiceProviderFactory());

        builder.Services.AddCors(cfg =>
        {

            cfg.AddPolicy("allowAll", p =>
            {

                p.AllowAnyHeader();
                p.AllowAnyMethod();
                p.AllowAnyOrigin();

            });

        });

        //builder.Services.AddControllers(cfg =>
        //{
        //    var policy = new AuthorizationPolicyBuilder()
        //                      .RequireAuthenticatedUser()
        //                      .Build();

        //    cfg.Filters.Add(new AuthorizeFilter(policy));
        //});

        builder.Services.AddDbContext<DbContext, DataContext>(cfg =>
        {
            string cs = builder.Configuration.GetConnectionString("cString");

            cfg.UseSqlServer(cs, opt =>
            {
                opt.MigrationsHistoryTable("MigrationHistory");
            });
        });

        //builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(HeaderBinderBehaviour<,>));

        builder.Services.Configure<CryptoServiceOptions>(cfg => builder.Configuration.Bind(nameof(CryptoServiceOptions), cfg));

        //builder.Services.AddCustomIdentity(builder.Configuration);

        builder.Services.AddScoped<IIdentityService, FakeIdentityService>();

        builder.Services.AddSingleton<IFileService, FileService>();

        builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

        builder.Services.AddControllersWithViews();

        builder.Services.AddRouting(cfg => cfg.LowercaseUrls = true);

        /*builder.Services.AddFluentValidationAutoValidation(cfg => cfg.DisableDataAnnotationsValidation = false);*/

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<IApplicationReferance>());

        builder.Services.AddRazorPages();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseCors("allowAll");

        //app.UseAuthorization();

        //app.UseAuthentication();

        app.MapRazorPages();

        app.MapControllers();

        app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

        app.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");

        app.Run();
    }
}