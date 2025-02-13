using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using URLShorter.Models;
using URLShorter.Services;
using Microsoft.Extensions.Primitives;


namespace URLShorter.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UrlShortenerService _urlShortenerService;
        
        public HomeController(ILogger<HomeController> logger, UrlShortenerService service)
        {
            _logger = logger;
            _urlShortenerService = service;
        }

        public IActionResult Index()
        {
         
            var AllowedUrls = _urlShortenerService.GetUrls();
            return View(AllowedUrls.Result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUrl(string ID)
        {
            try
            {
                await _urlShortenerService.DeleteUrl(ID);
            }
            catch (Exception ex) { }
            return Redirect("~/Home/Index");
            
        }

        [HttpGet("/{shortUrl}")]

        public async Task<IActionResult> RedirectToOriginalUrl(string shortUrl)
        {
            try
            {
                var FullUrls = await _urlShortenerService.GetFullUrl(shortUrl);
                await _urlShortenerService.AddRedirection(FullUrls);
                return RedirectPermanent(FullUrls.Url);
            }
            catch (Exception ex) 
            {
                return Redirect("~/Home/Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddNewUrl(string FullUrl)
        {
            try
            {
                await _urlShortenerService.AddNewUrl(FullUrl);
            }
            catch (Exception ex) { }

            return Redirect("~/Home/AddUrl");
            
        }

        public IActionResult AddUrl()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
