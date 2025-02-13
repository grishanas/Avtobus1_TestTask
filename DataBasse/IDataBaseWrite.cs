using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBasse
{
    public interface IDataBaseWrite
    {
        public Task<bool> AddUrlAsync(UrlInfo url);
        public Task<bool> IncrementClick(UrlInfo url);

    }
}
