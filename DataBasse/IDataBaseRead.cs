using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBasse
{
    public interface IDataBaseRead
    {
        public Task<IEnumerable<UrlInfo>> GetUrlsAsync();

        public Task<UrlInfo> GetUrlAsync(string shortUrl);

    }
}
