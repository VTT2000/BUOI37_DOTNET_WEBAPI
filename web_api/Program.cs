// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Thêm service controllers
builder.Services.AddControllers();
//Cho phép các domain client được gửi dữ liệu (POST,PUT,DELETE)
builder.Services.AddCors(option=>{
    option.AddPolicy("allow_origin", policy => {
        // policy.AllowAnyOrigin(); //Cho phép tất cả các client đều có thể gửi dữ liệu đến server
        policy.WithOrigins("https://localhost:5001","https://login.cybersoft.edu.vn")
        .AllowAnyHeader() //Cho phép rq tất cả header
        .AllowAnyMethod() //Cho phép rq tất cả method (POST,PUT,GET,DELETE,OPTION)
        .AllowCredentials(); ////Cho phép cookie...

    });
});

var app = builder.Build();
//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("allow_origin");

//map các route controller vào swagger
app.MapControllers();


app.UseHttpsRedirection();
app.Run();

