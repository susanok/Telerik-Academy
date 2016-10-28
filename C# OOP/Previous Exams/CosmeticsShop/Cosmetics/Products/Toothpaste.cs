namespace Cosmetics.Products
{
    using Common;
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Toothpaste : Product, IToothpaste
    {
        private const int MinLength = 4;
        private const int MaxLength = 12;
        private const string EachIngredientToString = "Each ingredient";

        private string message = string
            .Format(GlobalErrorMessages
            .InvalidStringLength, EachIngredientToString, MinLength, MaxLength);

        private IList<string> ingredientsList;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.IngredientsList = ingredients;
        }

        public string Ingredients
        {
            get
            {
                return string.Join(", ", this.ingredientsList);
            }
            
        }

        public IList<string> IngredientsList
        {
            get
            {
                return this.ingredientsList;
            }
            private set
            {
                foreach (var item in value)
                {
                    Validator.CheckIfStringLengthIsValid(item, MaxLength, MinLength, message);
                }

                this.ingredientsList = value;
            }
        }

        public object StrngBuilder { get; private set; }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.Print());
            result.AppendLine();
            result.AppendFormat("  * Ingredients: {0}", this.Ingredients);
            return result.ToString();
        }
    }
}
