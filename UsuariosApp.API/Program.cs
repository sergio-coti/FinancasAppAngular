using UsuariosApp.API.Extensions;
using UsuariosApp.Messages.Consumers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(config => config.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddJwtBearer();
builder.Services.AddCors(options => {
    options.AddPolicy("DefaultPolicy", policy => 
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("DefaultPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
