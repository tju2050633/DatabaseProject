using Garden.BLL;
using Garden.BLL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add BLL Singleton
builder.Services.AddSingleton<IAccountBLL, AccountBLL>();
builder.Services.AddSingleton<IBlogBLL, BlogBLL>();
builder.Services.AddSingleton<IGardenBLL, GardenBLL>();
builder.Services.AddSingleton<IVolunteerBLL, VolunteerBLL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

//服务端启用后端跨域请求协议
app.UseCors(builder =>
{
    builder.AllowAnyHeader()
           .AllowAnyOrigin()
           .AllowAnyMethod();
});

app.MapControllers();

app.Run();
