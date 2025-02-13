using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBasse
{
    public interface IDataBaseDelete
    {
        public Task<UrlInfo> DeleteAsync(UrlInfo url);
    }
}
