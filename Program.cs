using MessageBoard.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MessageBoard;

public class Program
{
  public static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var startup = new Startup(builder.Configuration);
    
    // Add services to the container.

    builder.Services.AddControllers();

    // builder.Services.AddDbContext<MessageBoardApiContext>(
    //                   dbContextOptions => dbContextOptions
    //                     .UseMySql(
    //                       builder.Configuration["ConnectionStrings:DefaultConnection"], 
    //                       ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"]
    //                     )
    //                   )
    //                 );
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddAuthentication();
 
    startup.ConfigureServices(builder.Services); // calling ConfigureServices method
  
    var app = builder.Build();

    startup.Configure(app, builder.Environment);// calling Configure method

    app.Run();
  }
}
