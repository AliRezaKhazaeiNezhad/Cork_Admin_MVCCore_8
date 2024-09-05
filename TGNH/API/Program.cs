var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient(typeof(TGNH.Logging.ILogger<>), typeof(TGNH.Logging.NLogAdapter<>));
builder.Services.AddTransient(typeof(TGNH.Logging.ILogger<>),typeof(TGNH.Logging.NLogAdapter<>));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
