using DataBasse;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Policy;

namespace URLShorter.Services
{
    public class UrlShortenerService
    {
        private IServiceScopeFactory scopeFactory;
        

        public UrlShortenerService(IServiceScopeFactory scope)
        {
           
            this.scopeFactory = scope;
        }
        public async Task<IEnumerable<UrlInfo>> GetUrls()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var dataBaseRead = scope.ServiceProvider.GetService<IDataBaseRead>();
                var urls = await dataBaseRead.GetUrlsAsync();
                return urls;
            }
        }

        public async Task DeleteUrl(string code)
        {
            var Url = await GetFullUrl(code);
            if (Url != null) 
            {
                using (var scope = scopeFactory.CreateScope())
                {
                    var deleter = scope.ServiceProvider.GetService<IDataBaseDelete>();
                    await deleter.DeleteAsync(Url);

                }
            }
        }

        public async Task AddRedirection(UrlInfo url)
        {
            using(var scope = scopeFactory.CreateScope())
            {
                var dataBaseWrite = scope.ServiceProvider.GetService<IDataBaseWrite>();
                url.incClick();
                await dataBaseWrite.IncrementClick(url);
            }
        }
        public async Task<UrlInfo?> GetFullUrl(string code)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var dataBaseRead = scope.ServiceProvider.GetService<IDataBaseRead>();
                var url = await dataBaseRead.GetUrlAsync(code);
                return url;
            }
            throw new NotImplementedException();
        }

        private async Task AddUrl(UrlInfo url)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var dataBaseWrite = scope.ServiceProvider.GetService<IDataBaseWrite>();
                var result = await dataBaseWrite.AddUrlAsync(url);
            }

        }
        public async Task AddNewUrl(string url)
        {
            var Url = new UrlInfo(url);
            var Urls = await this.GetUrls();
            if (Urls.FirstOrDefault(x => x.Url == url) != null) 
            {
                return;
            }

            var CodeGenerator = new CodeGenerator();

            string NewCode;
            do
            {
                NewCode = CodeGenerator.Generate();
            } while (Urls.FirstOrDefault(x => x.shortUrl == NewCode) != null);

            Url.shortUrl = NewCode;
            await this.AddUrl(Url);

            
        }
    }
}
