using Jia.SportsStore.Domain.Abstract;
using Jia.SportsStore.Domain.Concrete;
using Jia.SportsStore.Domain.Entities;
using System.Collections.Generic;

public class EFProductRepository : IProductsRepository
{
    private EFDbContext context = new EFDbContext();
    public IEnumerable<Product> Products
    {
        get { return context.Products; }
    }
    public void SaveProduct(Product product)
    {
        if (product.ProductId == 0)
        {
            context.Products.Add(product);
        }
        else
        {
            Product dbEntry = context.Products.Find(product.ProductId);
            if (dbEntry != null)
            {
                dbEntry.Name = product.Name;
                dbEntry.Description = product.Description;
                dbEntry.Price = product.Price;
                dbEntry.Category = product.Category;
            }
        }
        context.SaveChanges();
    }

    public Product DeleteProduct(int productID)
    {
        Product dbEntry = context.Products.Find(productID);
        if (dbEntry != null)
        {
            context.Products.Remove(dbEntry);
            context.SaveChanges();
        }
        return dbEntry;
    }
}