using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using S3Train.Contract;
using S3Train.Domain;
using S3Train.Models;

namespace S3Train.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductAdvertisementService _productAdvertisementService;

        public HomeController(IProductService productService, IProductAdvertisementService productAdvertisementService)
        {
            _productService = productService;
            _productAdvertisementService = productAdvertisementService;
        }

        public ActionResult Index()
        {
            var model = new HomeViewModel
            {
                SliderItems = GetHomeSlider(_productAdvertisementService.GetSliderItems()),
                Products = GetHomeProducts(_productService.SelectAll())
            };

            return View(model);
        }

        private static IList<ProductViewModel> GetHomeProducts(IList<Product> products)
        {
            return products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                ImagePath = x.ImagePath,
                Name = x.Name,
                DisplayPrice = $"${x.Price}",
                Rating = x.Rating ?? 0,
                Summary = x.Summary
            }).ToList();
        }

        private static IList<SliderItemViewModel> GetHomeSlider(IList<ProductAdvertisement> productAds)
        {
            return productAds.Select(x => new SliderItemViewModel
            {
                ImagePath = x.ImagePath,
                Title = x.Title
            }).ToList();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}