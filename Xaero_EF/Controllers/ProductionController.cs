using EF_Core.Models;
using Microsoft.AspNetCore.Mvc;
using Xaero_EF.Data;

namespace Xaero_EF.Controllers
{
    public class ProductionController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment webHostEnvironment;

        public ProductionController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductionCompany entity,IFormFile logo) 
        {
            if (logo == null) 
            {
                ModelState.AddModelError(nameof(entity.Logo) , "Please select logo file!");
            }
            if (ModelState.IsValid) 
            {
                string path = "Image/Production/" + logo.FileName;
                using (var streem = new FileStream(Path.Combine(webHostEnvironment.WebRootPath, path), FileMode.Create))
                {
                    await logo.CopyToAsync(streem);
                }

                var prodCompany = new ProductionCompany()
                {
                    Name = entity.Name,
                    Logo = "~/" + path,
                    AnnualReveune = entity.AnnualReveune,
                    EstablishmentDate = entity.EstablishmentDate
                };
                _context.ProductionCompany.Add(prodCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
