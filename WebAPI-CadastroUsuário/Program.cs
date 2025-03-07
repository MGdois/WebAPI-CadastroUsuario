using Microsoft.EntityFrameworkCore;
using WebAPI_CadastroUsuário.Data;
using WebAPI_CadastroUsuário.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirFrontEnd",
        policy => policy.WithOrigins("http://127.0.0.1:5500") // URL do seu front-end
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("PermitirFrontEnd"); // Habilita o CORS

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
