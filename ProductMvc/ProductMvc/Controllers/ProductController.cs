using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductMvc.Interfaces;
using ProductMvc.Models;

namespace ProductMvc.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.FindAll();

        return View(products);
    }

    [HttpGet()]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductModel productModel)
    {
        if (ModelState.IsValid)
        {
            await _productService.Create(productModel);
            return RedirectToAction(nameof(Index));
        }

        return View(productModel);
    }

    [HttpGet()]
    public async Task<IActionResult> Edit(int id)
    {
        if (id == null) return NotFound();

        var productDto = await _productService.Find(id);

        if (productDto == null) return NotFound();

        return View(productDto);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductModel productModel)
    {
        if (ModelState.IsValid)
        {
            await _productService.Update(productModel);
            return RedirectToAction(nameof(Index));
        }

        return View(productModel);
    }

    [HttpGet()]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var productDto = await _productService.Find(id.Value);

        if (productDto == null) return NotFound();

        return View(productDto);
    }

    [HttpPost(), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        if (id == null)
            return NotFound();

        await _productService.Delete(id.Value);

        return RedirectToAction("Index");
    }

    [HttpGet()]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var productDto = await _productService.Find(id.Value);

        if (productDto == null) return NotFound();

        return View(productDto);
    }
}
