using Microsoft.OpenApi.Models;
using Npgsql;
using backend;
using backend.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
//using swagger page in dev and prod envs for now
//can add if statement to only use swagger ui in dev env
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes api V1");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options =>
{
    // before publish use this
     options.WithOrigins("https://johnnotesapi.azurewebsites.net", "https://notes.johncorrigan.dev");

    //for local host deving
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    //options.AllowAnyOrigin();
    //options.AllowCredentials();
});

app.MapControllers();

app.Run();