using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DataBasse.DBConnection.ReadDbContext;
using Microsoft.EntityFrameworkCore;
using DataBasse.DBConnection.WriteDbContext;
using DataBasse.Queries;
using DataBasse.DBConnection.DeleteDbContext;


namespace DataBasse
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDbConnection(this IServiceCollection services,IConfiguration configuration) 
        {
            var connection = configuration.GetConnectionString("DataBase");
            if(connection == null) throw new ArgumentNullException(nameof(connection));

            services.AddDbContext<ShortUrlReadDbContext>(option=>option.UseMySQL(connection));
            services.AddDbContext<ShortUrlWriteDbContext>(option=>option.UseMySQL(connection));
            services.AddDbContext<ShortUrlDeleteDbContext>(option=>option.UseMySQL(connection));

            services.AddScoped<IDataBaseRead, UrlReader>();
            services.AddScoped<IDataBaseWrite, UrlWriter>();
            services.AddScoped<IDataBaseDelete, UrlDeleter>();

            return services;

          
        }
    }
}
