using Jia.SportsStore.Domain.Abstract;
using Jia.SportsStore.Domain.Entities;
using System.Linq;
using System.Web.Mvc;

public class AdminController : Controller
{
    private IProductsRepository repository;
    public AdminController(IProductsRepository repo)
    {
        repository = repo;
    }

    public ViewResult Edit(int productId)
    {
        Product product = repository
        .Products
        .FirstOrDefault(p => p.ProductId == productId);
        return View(product);
    }

    [HttpPost]
    public ActionResult Edit(Product product)
    {
        if (ModelState.IsValid)
        {
            repository.SaveProduct(product);
            TempData["message"] = string.Format("{0} has been saved", product.Name);
            return RedirectToAction("Index");
        }
        else
        {
            // there is something wrong with the data values
            return View(product);
        }
    }

    public ViewResult Index()
    {
        return View(repository.Products);
    }

    public ViewResult Create()
    {
        return View("Edit", new Product());
    }

    [HttpPost]
    public ActionResult Delete(int productId)
    {
        Product deletedProduct = repository.DeleteProduct(productId);
        if (deletedProduct != null)
        {
            TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
        }
        return RedirectToAction("Index");
    }

}