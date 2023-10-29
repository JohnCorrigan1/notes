using Microsoft.OpenApi.Models;
using Npgsql;
using backend;
using backend.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Notes api",
        Version = "v1"
    });
});

//use lowercase urls
builder.Services.AddRouting(options => options.LowercaseUrls = true);

//database setup
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//connect
await using var con = new NpgsqlConnection(connectionString);
await con.OpenAsync();

//add to context to use in controllers 
builder.Services.AddScoped(_ => new DB(con));

//add services to controllers context
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPostService, PostService>();

// CORS setup
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        //builder.WithOrigins("https://johnnotesapi.azurewebsites.net", "https://notes.johncorrigan.dev")
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes api V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseRouting();

app.UseCors();

app.MapControllers();

app.Run();
