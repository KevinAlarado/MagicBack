using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Magic.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Agregar elcontexto
builder.Services.AddDbContext<MagicContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("StaticConnection"));
}
);

//Integración del Json
builder.Services.AddControllers().AddNewtonsoftJson(
    options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
).AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());



var app = builder.Build();

//activar cores
app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
