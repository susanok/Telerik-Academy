namespace Cosmetics.Products
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Category : ICategory
    {
        private const string CategoryNameToString = "Category name";
        private const int MinLegth = 2;
        private const int MaxLength = 15;
        private const string ProductsInTotal = "{0} products in total";
        private const string ProductSingle = "{0} product in total";
        private const string CategoryString = "{0} category - ";

        private string messageLength = string.Format(GlobalErrorMessages.InvalidStringLength, CategoryNameToString, MinLegth, MaxLength);
        private string messageNull = string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, CategoryNameToString);

        private string name;
        private List<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                
                Validator.CheckIfStringLengthIsValid(value, MaxLength, MinLegth, messageLength);
                Validator.CheckIfStringIsNullOrEmpty(value, messageNull);
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            products.Add(cosmetics);
        }

        
        public string Print()
        {
            StringBuilder result = new StringBuilder();
            
            result.AppendFormat(CategoryString, this.Name);
            
            if(this.products.Count == 0)
            {
                result.AppendFormat(ProductsInTotal, this.products.Count);
            }
            else if(this.products.Count == 1)
            {
                result.AppendFormat(ProductSingle, this.products.Count);
                result.AppendLine();
                foreach (var product in products)
                {
                    result.Append(product.Print());
                }
            }
            else
            {
                result.AppendFormat(ProductsInTotal, this.products.Count);
                var sortedProducts = products.OrderBy(x => x.Brand).ThenByDescending(x => x.Price);
                foreach (var product in sortedProducts)
                {
                    result.AppendLine();
                    result.Append(product.Print());
                    
                }
            }
           
            return result.ToString();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            int index = products.IndexOf(cosmetics);
            if (index < 0)
            {
                string msg = string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name);
                throw new IndexOutOfRangeException();
            }

            products.RemoveAt(index);
        }
    }
}
