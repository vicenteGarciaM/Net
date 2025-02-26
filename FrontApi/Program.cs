using Business;
using Data;
using Data.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
if (defaultConnection == null)
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(defaultConnection));
builder.Services.AddDbContext<LoginDbContext>(opciones => opciones.UseSqlServer(defaultConnection));

builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<LoginDbContext>();

builder.Services.AddScoped(typeof(Repository<>));
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ArticuloService>();
builder.Services.AddScoped<CompraService>();
builder.Services.AddScoped<InventarioService>();
builder.Services.AddScoped<TiendaService>();
builder.Services.AddScoped<CompraRepository>(provider =>
    new CompraRepository(defaultConnection));
builder.Services.AddScoped<InventarioRepository>(provider =>
    new InventarioRepository(provider.GetRequiredService<AppDbContext>()));
builder.Services.AddControllers();
builder.Services.AddAuthorization();

var origenPermitido = builder.Configuration.GetValue<string>("OrigenPermitido");

if (origenPermitido != null){
    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(politica =>
        {
            politica.WithOrigins(origenPermitido)
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
}



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.MapGroup("/identity").MapIdentityApi<IdentityUser>();

if (builder.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

