namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;
    using System.Text;

    public class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Number of legs can not be less or equal to zero.");
                }

                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendFormat(", Legs: {0}", this.NumberOfLegs);
            return result.ToString();
        }
    }
}
