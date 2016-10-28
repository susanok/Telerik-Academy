namespace FurnitureManufacturer.Models
{
    using System;
    using FurnitureManufacturer.Interfaces;
    using System.Text;

    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(string model, MaterialType material, decimal price, decimal height) : base(model, material, price, height)
        {
        }

        public Table(string model, MaterialType material, decimal price, decimal height, decimal length, decimal width)
            : base(model, material, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Area
        {
            get
            {
                return this.Width * this.Length;
            }
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if(value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Length can not be less or equal to zero.");
                }

                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Width can not be less or equal to zero.");
                }

                this.width = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendFormat(", Length: {0}, Width: {1}, Area: {2}", this.Length, this.Width, this.Area);
            return result.ToString();
        }
    }
}
