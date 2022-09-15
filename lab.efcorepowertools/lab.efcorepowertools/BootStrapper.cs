using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using lab.efcorepowertools.Core;
using lab.efcorepowertools.Data;
using lab.efcorepowertools.EntityModels;
using lab.efcorepowertools.Identity;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace lab.efcorepowertools
{
    public class BootStrapper
    {
        public static void Run(IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddRouting(options => options.LowercaseUrls = true);

                // Initializes and seeds the database.
                InitializeAndSeedDbAsync(configuration);
            }
            catch (Exception)
            {
                throw;
            }

        }

        private static void InitializeAndSeedDbAsync(IConfiguration configuration)
        {
            try
            {
                AppConstants.IsDatabaseCreate = configuration["AppConfig:IsDatabaseCreate"] == null ? true : bool.Parse(configuration["AppConfig:IsDatabaseCreate"].ToString());
                AppConstants.IsMasterDataInsert = configuration["AppConfig:IsMasterDataInsert"] == null ? true : bool.Parse(configuration["AppConfig:IsMasterDataInsert"].ToString());
                if (!AppConstants.IsDatabaseCreate)
                {
                    using (var context = new AppDbContext())
                    {
                        var canConnect = context.Database.CanConnect();
                        if (!canConnect)
                        {
                            if (AppDbContextInitializer.CreateIfNotExists())
                            {
                                if (!AppConstants.IsMasterDataInsert)
                                {
                                    AppDbContextInitializer.SeedData();
                                }
                            }
                        }
                    }
                }
                
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
