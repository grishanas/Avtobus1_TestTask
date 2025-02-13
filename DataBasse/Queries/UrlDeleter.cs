using DataBasse.DBConnection.DeleteDbContext;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBasse.Queries
{
    internal class UrlDeleter:IDataBaseDelete
    {
        private readonly ShortUrlDeleteDbContext _context;

        public UrlDeleter(ShortUrlDeleteDbContext context)
        {
            _context = context;
        }
        public async  Task<UrlInfo> DeleteAsync(UrlInfo url)
        {
            try
            {
                _context.Database.CanConnect();
                _context.Urls.Remove(url);
                var res = await _context.SaveChangesAsync();
                return url;
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }
    }
}
