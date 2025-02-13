using DataBasse.DBConnection.WriteDbContext;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBasse.Queries
{
    public class UrlWriter : IDataBaseWrite
    {
        private readonly ShortUrlWriteDbContext _dbContext;

        public UrlWriter(ShortUrlWriteDbContext context)
        {
            _dbContext = context;
        }
        public async Task<bool> AddUrlAsync(UrlInfo url)
        {
            try
            {
                _dbContext.Database.OpenConnection();
                var result = await _dbContext.Urls.AddAsync(url);
                await _dbContext.SaveChangesAsync();
                return true;              

            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }
        public async Task<bool> IncrementClick(UrlInfo url)
        {
            try
            {
                _dbContext.Urls.Update(url);
                await _dbContext.SaveChangesAsync();

            }
            catch (Exception ex) { }
            return true;
            
        }


    }
}
