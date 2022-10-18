using CodecoolAdvanced.Model;
using CodecoolAvence.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
Student student = new Student("alma", Branch.Java, "alama@alama.hu");
Student student1 = new Student("korte", Branch.C_sharp, "korte@korte.hu");
Team team = new Team(student, "almak");
TeamCollector.Instance.AddTeam(team);
UserCollector.Instance.AddUsersToCollector(student);
UserCollector.Instance.AddUsersToCollector(student1);


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
