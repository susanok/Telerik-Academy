namespace Dealership.Models
{
    using System;
    using Dealership.Contracts;
    using Dealership.Common;
    using Dealership.Common.Enums;
    using System.Text;

    public class Truck : Vehicle, ITruck
    {
        private const string WeightCapacityAsString = "Weight capacity";

        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(make, model, price)
        {
            this.WeightCapacity = weightCapacity;
            this.Type = VehicleType.Truck;
            this.Wheels = (int)VehicleType.Truck;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            private set
            {
                Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity,
                    String.Format(Constants.NumberMustBeBetweenMinAndMax, Truck.WeightCapacityAsString,
                    Constants.MinCapacity, Constants.MaxCapacity));

                this.weightCapacity = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendFormat("  Weight Capacity: {0}t", this.WeightCapacity);
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
