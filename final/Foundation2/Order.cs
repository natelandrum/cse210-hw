using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text;


public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;
        foreach (var product in _products)
        {
            totalPrice += product.GetTotalPrice();
        }
        totalPrice += _customer.IsDomestic() ? 5 : 35;

        return totalPrice;
    }

    public string GeneratePackingLabel()
    {
        StringBuilder sb = new StringBuilder();

        foreach (Product product in _products)
        {
            sb.AppendLine(product.GetProductDetails());
        }

        return sb.ToString();
    }

    public string GenerateShippingLabel()
    {
        return _customer.GetShippingInfo();
    }
}