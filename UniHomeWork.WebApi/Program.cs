using UniHomeWork.Infrastructure.Implementation;
using UniHomeWork.Infrastructure.Interfaces;
using UniHomeWork.Logic.Implementation;
using UniHomeWork.Logic.Interface;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InMemoryContext>();

builder.Services.AddControllers();

builder.Services.AddTransient<IEntityLogic, EntityLogic>();
builder.Services.AddTransient<IInMemoryContext, InMemoryContext>();

var app = builder.Build();

var scope = app.Services.CreateScope();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
