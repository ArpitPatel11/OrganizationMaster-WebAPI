using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OrganizationMaster.Data;
using OrganizationMaster.Models;

var builder = WebApplication.CreateBuilder(args);
var AngularWeb = "_AngularWeb";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmailServices, EmailServices>();

builder.Services.AddCors(options => options.AddPolicy(name: AngularWeb,
    builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    }
    ));

//builder.Services.AddCors(cors => cors.AddPolicy("MyPolicy", builder =>
//{
//    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true);
//}));  


builder.Services.AddDbContext<OrganizationMaster.Data.FirstDBContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
    }
    );

builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(AngularWeb);
//app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
