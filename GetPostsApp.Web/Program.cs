using GetPostsApp.API.Middlewares;
using GetPostsApp.API.StartupSetup;
using GetPostsApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Logging.AddLogger(configuration);

builder.Services
  .AddDataBaseConfig(configuration)
  .RegisterServices(configuration)
  .AddSwagger()
  .AddControllers();

var app = builder.Build();

using (var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
  var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
  if (context.Database.GetPendingMigrations().Any())
  {
    context.Database.Migrate();
  }
}


app.UseMiddleware<GeneralExceptionMiddleware>();
app.UseMiddleware<LogginigRequestMiddleware>();

if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
