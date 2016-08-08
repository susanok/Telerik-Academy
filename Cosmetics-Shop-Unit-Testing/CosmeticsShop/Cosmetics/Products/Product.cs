namespace Cosmetics.Products
{
    using Common;
    using Contracts;
    using System.Text;

    public class Product : IProduct
    {
        private const string ProductNameToString = "Product name";
        private const string ProductBrandToString = "Product brand";
        private const string GenderToString = "Gender";
        private const string PriceToString = "Price";
        private const int MinLengthName = 3;
        private const int MaxLength = 10;
        private const int MinLenghtBrand = 2;

        private string messageLengthBrand = string
            .Format(GlobalErrorMessages
            .InvalidStringLength, ProductBrandToString, MinLenghtBrand, MaxLength);
        private string messageLengthName = string
            .Format(GlobalErrorMessages
            .InvalidStringLength, ProductNameToString, MinLengthName, MaxLength);
        private string messageNullOrEmptyBrand = string
            .Format(GlobalErrorMessages
            .StringCannotBeNullOrEmpty, ProductBrandToString);
        private string messageNullOrEmptyName = string
            .Format(GlobalErrorMessages
            .StringCannotBeNullOrEmpty, ProductNameToString);
        private string messageNullPrice = string
            .Format(GlobalErrorMessages
            .ObjectCannotBeNull, PriceToString);
        private string messageNullGender = string
            .Format(GlobalErrorMessages
            .ObjectCannotBeNull, GenderToString);

        private string brand;
        private GenderType gender;
        private string name;
        private decimal price;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                Validator.CheckIfStringLengthIsValid(value, MaxLength, MinLenghtBrand, messageLengthBrand);
                Validator.CheckIfStringIsNullOrEmpty(value, messageNullOrEmptyBrand);
                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
            private set
            {
                Validator.CheckIfNull(value, messageNullGender);
                this.gender = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckIfStringLengthIsValid(value, MaxLength, MinLengthName, messageLengthName);
                Validator.CheckIfStringIsNullOrEmpty(value, messageNullOrEmptyName);
                this.name = value;
            }
        }

        public virtual decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                Validator.CheckIfNull(value, messageNullPrice);
                this.price = value;
            }
        }

        public virtual string Print()
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat("- {0} - {1}:", this.Brand, this.Name);
            result.AppendLine();
            result.AppendFormat("  * Price: ${0}", this.Price);
            result.AppendLine();
            result.AppendFormat("  * For gender: {0}", this.Gender);

            return result.ToString();
        }
    }
}
