using AMR.DA;
using AMR.DA.Contexto;
using AMR.DA.Interfaces;
using AMR.RN;
using AMR.RN.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IHomeRN, HomeRN>();
builder.Services.AddScoped<IHomeDA, HomeDA>();

builder.Services.AddScoped<IFacilidadesRN, FacilidadesRN>();
builder.Services.AddScoped<IFacilidadesDA, FacilidadDA>();

builder.Services.AddScoped<IPublicidadRN, PublicidadRN>();
builder.Services.AddScoped<IPublicidadDA, PublicidadDA>();

builder.Services.AddScoped<ISobreNosotrosRN, SobreNosotrosRN>();
builder.Services.AddScoped<ISobreNosotrosDA, SobreNosotrosDA>();

builder.Services.AddScoped<IReservaRN, ReservaRN>();
builder.Services.AddScoped<IReservaDA, ReservaDA>();

builder.Services.AddScoped<IHabitacionRN, HabitacionRN>();
builder.Services.AddScoped<IHabitacionDA, HabitacionDA>();

builder.Services.AddScoped<ITipoHabitacionRN, TipoHabitacionRN>();
builder.Services.AddScoped<ITipoHabitacionDA, TipoHabitacionDA>();

builder.Services.AddScoped<IComoLlegarRN, ComoLlegarRN>();
builder.Services.AddScoped<IComoLlegarDA, ComoLlegarDA>();

builder.Services.AddScoped<IContactenosRN, ContactenosRN>();
builder.Services.AddScoped<IContactenosDA, ContactenosDA>();

builder.Services.AddScoped<IAdministradorRN, AdministradorRN>();
builder.Services.AddScoped<IAdministradorDA, AdministradorDA>();

builder.Services.AddScoped<ITemporadaRN, TemporadaRN>();
builder.Services.AddScoped<ITemporadaDA, TemporadaDA>();


//Conexión a BD
builder.Services.AddDbContext<ContextoBD>(options =>
{
    var connectionString = "workstation id=arenaymar.mssql.somee.com;packet size=4096;user id=diego1234_SQLLogin_1;pwd=o81yios9jl;data source=arenaymar.mssql.somee.com;persist security info=False;initial catalog=arenaymar;TrustServerCertificate=True";
    options.UseSqlServer(connectionString);
});





var app = builder.Build();

app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();
// Configure CORS para permitir solicitudes desde cualquier origen
// Puedes ajustar AllowAnyOrigin, AllowAnyMethod y AllowAnyHeader según tus necesidades
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();