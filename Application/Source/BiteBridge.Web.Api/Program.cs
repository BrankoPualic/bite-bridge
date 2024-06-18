using BiteBridge.Common.Interfaces;
using BiteBridge.DependencyInjection;
using BiteBridge.Web.Api.Middlewares;
using BiteBridge.Web.Api.Objects;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowedCrossOrigins",
		builder =>
		{
			builder.WithOrigins
				(
					"https://localhost:4200",
					"http://localhost:4200"
				)
				.AllowAnyMethod()
				.AllowAnyHeader();
		});
});

builder.Services.AllApplicationServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IIdentityUser, IdentityUser>();

var app = builder.Build();

app.UseCors("AllowedCrossOrigins");

app.UseHttpsRedirection();
app.UseRouting();

app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();