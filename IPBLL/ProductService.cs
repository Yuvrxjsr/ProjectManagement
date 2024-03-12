using IPDAL;
using ProductManagement.Models;

namespace IPBLL;

public class ProductService
{
    public List<product> GetProducts()
    {
        ProductRepository pr = new ProductRepository();
        return pr.GetProductsRepo();
    }

    public product GetProduct(int id)
    {
        ProductRepository pr = new ProductRepository();
        return pr.GetProductByIdRepo(id);
    }

    public bool DeleteProduct(int ProductID)
    {
        ProductRepository pr = new ProductRepository();
        return pr.DeleteProductRepo(ProductID);
    }


    public bool AddProduct(product Product)
    {
        ProductRepository pr = new ProductRepository();

        if (ValidatePriceAndQuantity(Product))
        {
            return pr.AddProductRepo(Product);
        }
        else
        {
            return false;
        }
    }

    public bool UpdateProduct(product Product)
    {
        ProductRepository pr = new ProductRepository();

        if (ValidatePriceAndQuantity(Product))
        {
            return pr.UpdateProductRepo(Product);
        }
        else
        {
            return false;
        }
    }

    public bool ValidatePriceAndQuantity(product Product)
    {
        return true ? Product.Price > 0 && Product.Quantity > 0 : false;
    }
}