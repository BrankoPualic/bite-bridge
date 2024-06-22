using BiteBridge.Common.Interfaces;
using BiteBridge.DependencyInjection;
using BiteBridge.Web.Api.Middlewares;
using BiteBridge.Web.Api.Objects;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AllApplicationServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IIdentityUser, IdentityUser>();

var app = builder.Build();

app.UseCors(builder => builder
	.AllowAnyHeader()
	.AllowAnyMethod()
	.AllowCredentials()
	.WithOrigins("https://localhost:4200")
	);

app.UseHttpsRedirection();
app.UseRouting();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();