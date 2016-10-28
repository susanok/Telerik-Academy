namespace Dealership.Models
{
    using System;
    using Dealership.Contracts;
    using Dealership.Common;
    using Dealership.Common.Enums;
    using System.Text;

    public class Car : Vehicle, ICar
    {
        private const string SeatsAsString = "Seats";

        private int seats;

        public Car(string make, string model, decimal price, int seats)
            : base(make, model, price)
        {
            this.Seats = seats;
            this.Type = VehicleType.Car;
            this.Wheels = (int)VehicleType.Car;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            private set
            {
                Validator.ValidateIntRange(value, Constants.MinSeats, Constants.MaxSeats,
                    String.Format(Constants.NumberMustBeBetweenMinAndMax, Car.SeatsAsString, Constants.MinSeats, Constants.MaxSeats));

                this.seats = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append(base.ToString());
            result.AppendFormat("  Seats: {0}", this.Seats);
            result.AppendLine();
            if(this.Comments.Count > 0)
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
