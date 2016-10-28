namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Contracts;

    public class ShoppingCart : IShoppingCart
    {
        private IList<IProduct> products;

        public ShoppingCart()
        {
            products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            this.products.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            bool containsProduct = this.products.Contains(product);

            return containsProduct;
        }

        public void RemoveProduct(IProduct product)
        {
            this.products.Remove(product);
        }

        public decimal TotalPrice()
        {
            decimal totalprice = 0;

            foreach (var product in products)
            {
                totalprice += product.Price;
            }

            return totalprice;
        }
    }
}
