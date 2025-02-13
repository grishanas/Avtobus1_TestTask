using DataBasse.DBConnection.ReadDbContext;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBasse.Queries
{
    public class UrlReader : IDataBaseRead
    {
        private readonly ShortUrlReadDbContext _dbContext;
        public UrlReader(ShortUrlReadDbContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<IEnumerable<UrlInfo>> GetUrlsAsync()
        {
            try
            {
                var result = await _dbContext.Urls.ToListAsync();
                return result;
                
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }

        public async Task<UrlInfo> GetUrlAsync(string url)
        {
            try
            {
                return await _dbContext.Urls.FirstOrDefaultAsync(x=>x.shortUrl == url);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
            
        }
    }
}
