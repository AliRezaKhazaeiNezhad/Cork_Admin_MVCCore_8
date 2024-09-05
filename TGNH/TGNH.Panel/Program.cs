using NonFactors.Mvc.Grid;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddMvcGrid();

        builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddTransient(typeof(TGNH.Logging.ILogger<>), typeof(TGNH.Logging.NLogAdapter<>));
        builder.Services.AddTransient(typeof(TGNH.Logging.ILogger<>), typeof(TGNH.Logging.NLogAdapter<>));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseStatusCodePagesWithReExecute("/Error404");

        app.MapControllerRoute(
             "Error404",
             pattern: "/Error404",
             defaults: new { controller = "Home", action = "Error404" });

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}