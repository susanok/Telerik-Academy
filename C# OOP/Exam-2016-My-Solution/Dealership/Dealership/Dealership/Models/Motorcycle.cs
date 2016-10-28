namespace Dealership.Models
{
    using System;
    using Dealership.Contracts;
    using Dealership.Common;
    using Dealership.Common.Enums;
    using System.Text;

    public class Motorcycle : Vehicle, IMotorcycle
    {
        private const string CategoryAsString = "Category";

        private string category;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price)
        {
            this.Category = category;
            this.Type = VehicleType.Motorcycle;
            this.Wheels = (int)VehicleType.Motorcycle;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                int valueLength = value.Length;

                Validator.ValidateIntRange(valueLength, Constants.MinCategoryLength, Constants.MaxCategoryLength,
                    String.Format(Constants.StringMustBeBetweenMinAndMax, Motorcycle.CategoryAsString,
                    Constants.MinCategoryLength, Constants.MaxCategoryLength));
                Validator.ValidateNull(value, String.Format(Constants.VehicleCannotBeNull));

                this.category = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendFormat("  Category: {0}", this.Category);
            result.AppendLine();
            if (this.Comments.Count > 0)
            {
                result.AppendLine("    --COMMENTS--");
                foreach (var item in this.Comments)
                {
                    result.AppendLine("    ----------");
                    result.AppendFormat("    {0}", item.Content);
                    result.AppendLine();
                    result.AppendFormat("      User: {0}", item.Author);
                    result.AppendLine();

                    result.AppendLine("    ----------");
                }

                result.AppendLine("    --COMMENTS--");
            }
            else
            {
                result.AppendLine("    --NO COMMENTS--");
            }
            return result.ToString();
        }
    }
}
