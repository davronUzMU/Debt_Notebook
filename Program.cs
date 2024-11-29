using Debt_Notebook.Data;
using Debt_Notebook.Repositories.DebtRep;
using Debt_Notebook.Repositories.MessageRep;
using Debt_Notebook.Repositories.OrganizationRep;
using Debt_Notebook.Repositories.StateRep;
using Debt_Notebook.Repositories.UserRep;
using Debt_Notebook.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
                 options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

builder.Services.AddScoped<IDebtRepository, DebtRepository>();
builder.Services.AddScoped<ISendSMSMessage,SendSMSMessage>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<DebtService>();
builder.Services.AddScoped<OrganizationService>();
builder.Services.AddHttpClient<PlayMobileSMSService>();
builder.Services.AddScoped<StateService>();
builder.Services.AddScoped<UserService>();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
