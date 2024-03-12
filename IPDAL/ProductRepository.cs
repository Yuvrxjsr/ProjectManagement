using ProductManagement.Models;
using AutoMapper;
namespace IPDAL;

public class ProductRepository
{
    public List<product> GetProductsRepo()
    {
        ProductManagementContext pmc = new ProductManagementContext();
        return pmc.Products.ToList();
    }


    public bool AddProductRepo(product Product)
    {
        ProductManagementContext pmc = new ProductManagementContext();
        if (Product != null)
        {
            pmc.Products.Add(Product);
            pmc.SaveChanges();
            return true; // Return true upon successful addition
        }
        return false;
    }

    public bool UpdateProductRepo(product Product)
    {
        // get the existing object from context using product.ProductId
        ProductManagementContext pmc = new ProductManagementContext();
        product productToBeUpdated = pmc.Products.FirstOrDefault(x => x.ProductId == Product.ProductId);

        if (productToBeUpdated != null)
        {
            // assign new or updated object to the existing object
            // save changes
            productToBeUpdated.Name = Product.Name;
            productToBeUpdated.Description = Product.Description;
            productToBeUpdated.Price = Product.Price;
            productToBeUpdated.Quantity = Product.Quantity;
            productToBeUpdated.Category = Product.Category;
            productToBeUpdated.Supplier = Product.Supplier;
            pmc.SaveChanges();
            return true;
        }
        return false;

    }

    public bool DeleteProductRepo(int productId)
    {
        ProductManagementContext pmc = new ProductManagementContext();
        var Product = pmc.Products.Where(x => x.ProductId == productId).FirstOrDefault();
        if (Product != null)
        {
            pmc.Products.Remove(Product);
            pmc.SaveChanges();
            return true;
        }
        return false;
    }

    public product GetProductByIdRepo(int id)
    {
        ProductManagementContext pmc = new ProductManagementContext();
        return pmc.Products.FirstOrDefault(x => x.ProductId == id);
    }
}