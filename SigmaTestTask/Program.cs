using Microsoft.EntityFrameworkCore;
using SigmaTestTask.Context;
using SigmaTestTask.Repositories.Interfaces;
using SigmaTestTask.Repositories;
using SigmaTestTask.Services.Interfaces;
using SigmaTestTask.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CandidatesContext>(opt =>
                opt.UseSqlServer(builder.Configuration.GetConnectionString("CandidatesContext")));

builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
