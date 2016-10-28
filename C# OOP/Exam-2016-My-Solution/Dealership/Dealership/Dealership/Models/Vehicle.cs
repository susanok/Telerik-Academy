namespace Dealership.Models
{
    using System;
    using System.Collections.Generic;
    using Dealership.Common.Enums;
    using Dealership.Contracts;
    using Dealership.Common;
    using System.Text;

    abstract public class Vehicle : IVehicle
    {
        private const string PriceAsString = "Price";
        private const string MakeAsString = "Make";
        private const string ModelAsString = "Model";

        public VehicleType Type { get; protected set; }
        public int Wheels { get; protected set; }

        private string make;
        private string model;
        private decimal price;
        private IList<IComment> comments;
        public Vehicle(string make, string model, decimal price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.comments = new List<IComment>();
        }

        public IList<IComment> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            private set
            {
                int valueLength = value.Length;
                Validator.ValidateIntRange(valueLength, Constants.MinMakeLength, Constants.MaxMakeLength,
                    String.Format(Constants.StringMustBeBetweenMinAndMax, Vehicle.MakeAsString, Constants.MinMakeLength, Constants.MaxMakeLength));
                Validator.ValidateNull(value, Constants.VehicleCannotBeNull);

                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                int valueLenght = value.Length;
                Validator.ValidateIntRange(valueLenght, Constants.MinModelLength, Constants.MaxModelLength,
                    String.Format(Constants.StringMustBeBetweenMinAndMax, Vehicle.ModelAsString, Constants.MinModelLength, Constants.MaxModelLength));
                Validator.ValidateNull(value, Constants.VehicleCannotBeNull);

                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            private set
            {
                Validator.ValidateDecimalRange(value, Constants.MinPrice, Constants.MaxPrice,
                    String.Format(Constants.NumberMustBeBetweenMinAndMax, Vehicle.PriceAsString, Constants.MinPrice, Constants.MaxPrice));

                this.price = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendFormat("{0}:", this.Type);
            result.AppendLine();
            result.AppendFormat("  Make: {0}\n  Model: {1}\n  Wheels: {2}\n  Price: ${3}",
                this.Make, this.Model, this.Wheels, this.Price);
            result.AppendLine();
            return result.ToString();
        }
    }
}
