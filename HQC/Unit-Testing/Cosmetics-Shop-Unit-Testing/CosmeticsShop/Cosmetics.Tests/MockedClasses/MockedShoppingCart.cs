using Cosmetics.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.MockedClasses
{
    internal class MockedShoppingCart : ShoppingCart
    {
        public MockedShoppingCart()
        {
        }

        public IList<IProduct> Products
        {
            get
            {
                return base.products;
            }
        }

    }
}
