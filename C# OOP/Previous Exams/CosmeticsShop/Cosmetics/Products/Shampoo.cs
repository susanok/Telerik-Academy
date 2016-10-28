namespace Cosmetics.Products
{
    using Common;
    using Contracts;
    using System.Text;

    public class Shampoo : Product, IShampoo
    {
        private const string MillilitersToString = "Milliliters";
        private const string UsageToString = "Usage";

        private string messageNullMilliliters = string
            .Format(GlobalErrorMessages
            .ObjectCannotBeNull, MillilitersToString);
        private string messageNullUsage = string
            .Format(GlobalErrorMessages
            .ObjectCannotBeNull, UsageToString);

        private uint milliliters;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base(name, brand, price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }


        public uint Milliliters
        {
            get
            {
                return this.milliliters;
            }
            private set
            {
                Validator.CheckIfNull(value, messageNullMilliliters);
                this.milliliters = value;
            }
        }

        public UsageType Usage
        {
            get
            {
                return this.usage;
            }
            private set
            {
                Validator.CheckIfNull(value, messageNullUsage);
                this.usage = value;
            }
        }

        public override decimal Price
        {
            get
            {
                return base.Price * this.Milliliters;
            }
        }

        public override string Print()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.Print());
            result.AppendLine();
            result.AppendFormat("  * Quantity: {0} ml", this.Milliliters);
            result.AppendLine();
            result.AppendFormat("  * Usage: {0}", this.Usage);
            return result.ToString();
        }
    }
}
