////////////////////////////////////////////////////
//https://www.youtube.com/watch?v=8pH5Lv4d5-g&t=238s
//TIME: 57:10
//Minimal API's look alot more like Node.js
// TAKE A LOOK AT HIS DOTNET JUMPSTART COURSE 
// https://www.udemy.com/course/net-core...
////////////////////////////////////////////////////

//SINCE WE'RE GREATER THAN C#10, WE CAN USE THE GLOBAL NAMESPACE
global using SuperHeroAPI.Models;
global using SuperHeroAPI.Services.SuperHeroService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//************************************************************************************************************
//REGISTER THE SERVICES WE'VE MADE AND INCLUDED - A SCOPED SERVICE
//MEANS: WHENEVER WE RUN INTO THE ISuperHeroService interface USE THE SuperHeroService
//BECAUSE OF THIS YOU DONT HAVE TO TOUCH THE CONTROLLER IF YOU WANTED TO COME UP WITH A
//SuperHeroService2(). YOU'D SIMPLY TYPE: builder.Services.AddScoped<ISuperHeroService, SuperHeroService2>()
//************************************************************************************************************
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();

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
