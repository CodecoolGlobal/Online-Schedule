using CodecoolAdvanced.Model;
using CodecoolAvence.Model;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000");
        });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
Student student = new Student("alma", Branch.Java, "alama@alama.hu");
Student student1 = new Student("korte", Branch.C_sharp, "korte@korte.hu");
Team team = new Team(student, "almak", "https://github.com/CodecoolGlobal/el-proyecte-grande-sprint-1-csharp-nagyD88");
TeamCollector.Instance.AddTeam(team);
UserCollector.Instance.AddUsersToCollector(student);
UserCollector.Instance.AddUsersToCollector(student1);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
