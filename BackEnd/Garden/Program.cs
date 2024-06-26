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
builder.Services.AddSingleton<IAuditBLL, AuditBLL>();
builder.Services.AddSingleton<IBlogBLL, BlogBLL>();
builder.Services.AddSingleton<IGardenBLL, GardenBLL>();
builder.Services.AddSingleton<IVolunteerBLL, VolunteerBLL>();
builder.Services.AddSingleton<IItemsBLL, ItemsBLL>();
builder.Services.AddSingleton<IStatisticsBLL, StatisticsBLL>();
builder.Services.AddSingleton<IActivityBLL, ActivityBLL>();
builder.Services.AddSingleton<IAdminBLL, AdminBLL>();
builder.Services.AddSingleton<ISearchBLL, SearchBLL>();
builder.Services.AddSingleton<IHotBLL, HotBLL>();
builder.Services.AddSingleton<ICollegeIdlyBLL, CollegeIdlyBLL>();
builder.Services.AddSingleton<IFeedbackBLL, FeedbackBLL>();
builder.Services.AddSingleton<INotifyBLL, NotifyBLL>();
builder.Services.AddSingleton<ILoginInfoBLL, LoginInfoBLL>();

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
