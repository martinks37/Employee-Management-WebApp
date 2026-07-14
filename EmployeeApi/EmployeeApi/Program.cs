using EmployeeApi.Data;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSingleton<DatabaseHelper>();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.AllowAnyOrigin()    // allow ALL origin
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{ //app.UseSwagger();
   // app.UseSwaggerUI();
//}
app.UseCors("AllowAngular");

app.UseAuthorization();
app.MapControllers();
app.Run();
