namespace Cosmetics.Engine
{
    using System.Collections.Generic;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;

    public class CosmeticsFactory : ICosmeticsFactory
    {
        public ICategory CreateCategory(string name)
        {
            Category category = new Category(name);
            return category;
        }

        public IShampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            Shampoo shampoo = new Shampoo(name, brand, price, gender, milliliters, usage);
            return shampoo;
        }

        public IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            Toothpaste toothpaste = new Toothpaste(name, brand, price, gender, ingredients);
            return toothpaste;
        }

        public IShoppingCart ShoppingCart()
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            return shoppingCart;
        }
    }
}
