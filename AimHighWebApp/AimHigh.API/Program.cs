using AimHigh.PL.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.


        builder.Services.AddSignalR()
            .AddJsonProtocol(options =>
            {
                options.PayloadSerializerOptions.PropertyNamingPolicy = null;
            });


        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "AimHigh API",
                Version = "v1",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "Gerald Vallejos",
                    Email = "vallejos@fvtc.edu",
                    Url = new Uri("https://www.fvtc.edu")
                }

            });


            var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"; //get me the name of the file
            var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile); // get me the path of the file
            c.IncludeXmlComments(xmlpath); //include the file in the swagger documentation

        });



        //Add Connection information


        builder.Services.AddDbContextPool<AimHighEntities>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("MonsterRemoteDb"));
            options.UseLazyLoadingProxies();
        }
            );

        var app = builder.Build();

        app.UseSwagger();

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        ///{
            app.UseSwaggerUI();
       // }

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        // app.MapControllers();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            //endpoints.MapHub<BingoHub>("/bingoHub");
        });

        app.Run();
    }
}