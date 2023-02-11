using E_Commerce.Data;
using E_Commerce.Interface;
using E_Commerce.Models;
using E_Commerce.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Controllers
{
    public class ProductController : Controller
    {
       // private readonly AppDbContext _context;

        public readonly IProductRepository _ProductRepository;
        private readonly IPhotoServices _photoServices;

        public ProductController(/*AppDbContext context,*/IProductRepository productRepository,IPhotoServices photoServices)
        {
           // _context = context;
            _ProductRepository = productRepository;
            _photoServices = photoServices;
        }


    // public IActionResult Index()
       public async Task<IActionResult> Index()
        { 
            //List<Product> products= _context.Product.ToList();
            IEnumerable<Product> products = await _ProductRepository.GetAll();
            return View(products);
        }
        public async Task<IActionResult> Details(string name)
        {
          //  var details =await _context.Product.FirstOrDefaultAsync(obj => obj.Product_Name == name);
            return View();

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(/*Product product*/ CreateProductVM productVM)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(product);
            //}
            //_ProductRepository.Add(product);

            //return RedirectToAction("Index");
            /******************************************************/

            if (ModelState.IsValid)
            {
                var result = await _photoServices.AddPhotoAsyn(productVM.Product_Image);
                var product = new Product
                {
                    Product_Name = productVM.Product_Name,
                    Product_Description = productVM.Product_Description,
                    Product_Category = productVM.Product_Category,
                    Product_Image = result.Url.ToString(),
                    Product_Price = productVM.Product_Price
                };
                _ProductRepository.Add(product);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("","Photo upload failed");
            }
            return View(productVM);
        }


  

    }
}
